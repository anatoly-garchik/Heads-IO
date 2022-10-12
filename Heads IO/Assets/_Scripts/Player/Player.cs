using System;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private FoodCollector _foodCollector;
        [SerializeField] private GrowthController _growthController;

        public float AmountPoints { get; private set; } = 10;

        public event Action Died;
        
        private void Awake()
        {
            _foodCollector.EatTaken += AddPoints;
            _foodCollector.BotTriggered += TryTakeBotPoints;
        }

        public void KillPlayer()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }

        private void AddPoints(float points)
        {
            if (points > 0)
            {
                AmountPoints += points;
            }
        }

        private void TryTakeBotPoints(Bot.Bot bot)
        {
            if (bot.AmountPoints < AmountPoints)
            {
                AddPoints(bot.AmountPoints);
                _growthController.IncreaseCharacter(bot.AmountPoints);
                Destroy(bot.gameObject);
            }
        }

        private void OnDestroy()
        {
            _foodCollector.EatTaken -= AddPoints;
            _foodCollector.BotTriggered -= TryTakeBotPoints;
        }
    }
}
