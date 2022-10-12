using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyPointsHandler : MonoBehaviour
    {
        [SerializeField] private EnemyCollectorTrigger _enemyCollectorTrigger;
        [SerializeField] private GrowthController _growthController;
        [SerializeField] private int _defaultPoints;

        public int AmountPoints { get; private set; }

        private void Awake()
        {
            AmountPoints = _defaultPoints;
            
            _enemyCollectorTrigger.FoodTriggered += TakeFood;
            _enemyCollectorTrigger.PlayerTriggered += TryEatPlayer;
        }

        private void TakeFood(Food.Food food)
        {
            AmountPoints += food.Points;
            _growthController.IncreaseCharacter(food.Points);
            food.Take();
        }

        private void TryEatPlayer(PlayerPointsHandler playerPointsHandler)
        {
            if (AmountPoints <= playerPointsHandler.AmountPoints) return;
            
            if (playerPointsHandler.gameObject.TryGetComponent(out DeathHandler deathHandler))
                deathHandler.Kill();
        }

        private void OnDestroy()
        {
            _enemyCollectorTrigger.FoodTriggered -= TakeFood;
            _enemyCollectorTrigger.PlayerTriggered -= TryEatPlayer;
        }
    }
}
