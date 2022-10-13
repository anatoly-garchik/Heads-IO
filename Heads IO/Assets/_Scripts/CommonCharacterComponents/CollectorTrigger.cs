using System;
using UnityEngine;

namespace _Scripts.CommonCharacterComponents
{
    public class CollectorTrigger : MonoBehaviour
    {
        public event Action<Food.Food> FoodTriggered;
        public event Action<Player.Player> PlayerTriggered; 
        public event Action<Enemy.Enemy> EnemyTriggered; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Food.Food food))
                FoodTriggered?.Invoke(food);

            if (other.TryGetComponent(out Player.Player player))
                if (other.gameObject != gameObject)
                    PlayerTriggered?.Invoke(player);
            
            if (other.TryGetComponent(out Enemy.Enemy enemy))
                if (other.gameObject != gameObject)
                    EnemyTriggered?.Invoke(enemy);
        }
    }
}
