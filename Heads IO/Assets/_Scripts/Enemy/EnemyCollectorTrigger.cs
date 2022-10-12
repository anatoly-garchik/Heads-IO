using System;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyCollectorTrigger : MonoBehaviour
    {
        public event Action<Food.Food> FoodTriggered;
        public event Action<PlayerPointsHandler> PlayerTriggered; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Food.Food food))
                FoodTriggered?.Invoke(food);

            if (other.TryGetComponent(out PlayerPointsHandler playerPointsHandler))
                PlayerTriggered?.Invoke(playerPointsHandler);
        }
    }
}
