using System;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerCollectorTrigger : MonoBehaviour
    {
        public event Action<Food.Food> FoodTriggered;
        public event Action<EnemyPointsHandler> EnemyTriggered; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Food.Food food))
                FoodTriggered?.Invoke(food);

            if (other.TryGetComponent(out EnemyPointsHandler enemyPointsHandler))
                EnemyTriggered?.Invoke(enemyPointsHandler);
        }
    }
}
