using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerCollectHandler : MonoBehaviour
    {
        [SerializeField] private CollectorTrigger _collectorTrigger;
        [SerializeField] private PointsStorage _pointsStorage;
        
        private void Awake()
        {
            _collectorTrigger.FoodTriggered += TakeFood;
            _collectorTrigger.EnemyTriggered += TryEatEnemy;
        }

        private void TakeFood(Food.Food food)
        {
            _pointsStorage.AddPoints(food.Points);
            food.Take(transform);
        }

        private void TryEatEnemy(Enemy.Enemy enemy)
        {
            if (_pointsStorage.AmountPoints <= enemy.PointsStorage.AmountPoints) return;
            
            _pointsStorage.AddPoints(enemy.PointsStorage.AmountPoints);
            enemy.DeathHandler.Kill();
        }
        
        private void OnDestroy()
        {
            _collectorTrigger.FoodTriggered -= TakeFood;
            _collectorTrigger.EnemyTriggered -= TryEatEnemy;
        }
    }
}
