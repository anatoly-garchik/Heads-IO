using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyCollectorHandler : MonoBehaviour
    {
        [SerializeField] private CollectorTrigger _collectorTrigger;
        [SerializeField] private PointsStorage _pointsStorage;
       
        private void Awake()
        {
            _collectorTrigger.FoodTriggered += TakeFood;
            _collectorTrigger.PlayerTriggered += TryEatPlayer;
            _collectorTrigger.EnemyTriggered += TryEatEnemy;
        }

        private void TakeFood(Food.Food food)
        {
            _pointsStorage.AddPoints(food.Points);
            food.Take();
        }

        private void TryEatPlayer(Player.Player player)
        {
            if (_pointsStorage.AmountPoints <= player.PointsStorage.AmountPoints) return;
            
            _pointsStorage.AddPoints(player.PointsStorage.AmountPoints);
            player.DeathHandler.Kill();
        }

        private void TryEatEnemy(Enemy enemy)
        {
            if (_pointsStorage.AmountPoints <= enemy.PointsStorage.AmountPoints) return;
            
            _pointsStorage.AddPoints(enemy.PointsStorage.AmountPoints);
            enemy.DeathHandler.Kill();
        }

        private void OnDestroy()
        {
            _collectorTrigger.FoodTriggered -= TakeFood;
            _collectorTrigger.PlayerTriggered -= TryEatPlayer;
            _collectorTrigger.EnemyTriggered -= TryEatEnemy;
        }
    }
}
