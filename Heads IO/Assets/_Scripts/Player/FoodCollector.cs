using System;
using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class FoodCollector : MonoBehaviour
    {
        [SerializeField] private bool _isCanCheckPlayer;
        [SerializeField] private bool _isCanCheckBot;
        
        [Inject] private FoodSpawner _foodSpawner;
        
        public event Action<float> EatTaken; 
        public event Action<Player> PlayerTriggered; 
        public event Action<Bot.Bot> BotTriggered; 
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Eat.Eat eat))
            {
                EatTaken?.Invoke(eat.Points);
                _foodSpawner.RemoveFood(eat.gameObject);
                //Destroy(eat.gameObject);
            }

            if (other.TryGetComponent(out Player player) && _isCanCheckPlayer)
            {
                PlayerTriggered?.Invoke(player);
            }

            if (other.TryGetComponent(out Bot.Bot bot) && _isCanCheckBot)
            {
                if (other.gameObject != gameObject)
                    BotTriggered?.Invoke(bot);
            }
        }
    }
}
