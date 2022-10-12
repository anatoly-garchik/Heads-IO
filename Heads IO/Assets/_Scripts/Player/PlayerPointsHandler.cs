using System;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerPointsHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCollectorTrigger playerCollectorTrigger;
        [SerializeField] private GrowthController _growthController;
        [SerializeField] private int _defaultPoints;
            
        public int AmountPoints { get; private set; }

        private void Awake()
        {
            AmountPoints = _defaultPoints;
            
            playerCollectorTrigger.FoodTriggered += TakeFood;
            playerCollectorTrigger.EnemyTriggered += TryEatEnemy;
        }

        private void TakeFood(Food.Food food)
        {
            AddPoints(food.Points);
            food.Take();
        }

        private void TryEatEnemy(EnemyPointsHandler enemyPointsHandler)
        {
            if (AmountPoints <= enemyPointsHandler.AmountPoints) return;
            
            AddPoints(enemyPointsHandler.AmountPoints);
                
            if (enemyPointsHandler.gameObject.TryGetComponent(out DeathHandler deathHandler))
                deathHandler.Kill();
        }

        private void AddPoints(int points)
        {
            AmountPoints += points;
            _growthController.IncreaseCharacter(points);
        }

        private void OnDestroy()
        {
            playerCollectorTrigger.FoodTriggered -= TakeFood;
            playerCollectorTrigger.EnemyTriggered -= TryEatEnemy;
        }
    }
}
