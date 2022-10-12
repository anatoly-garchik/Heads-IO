using System;
using _Scripts.Player;
using UnityEngine;

namespace _Scripts.Bot
{
    public class Bot : MonoBehaviour
    {
        [SerializeField] private FoodCollector _foodCollector;
        [SerializeField] private GrowthController _growthController;

        public float AmountPoints { get; private set; } = 1;

        private void Awake()
        {
            _foodCollector.EatTaken += AddPoints;
            _foodCollector.PlayerTriggered += TryTakePlayerPoints;
            _foodCollector.BotTriggered += TryTakeBotPoints;
        }

        private void AddPoints(float points)
        {
            if (points > 0)
                AmountPoints += points;
        }

        private void TryTakePlayerPoints(Player.Player player)
        {
            if (player.AmountPoints < AmountPoints)
            {
                AmountPoints += player.AmountPoints;
                _growthController.IncreaseCharacter(player.AmountPoints);
                player.KillPlayer();
            }
        }
        private void TryTakeBotPoints(Bot bot)
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
            _foodCollector.PlayerTriggered -= TryTakePlayerPoints;
            _foodCollector.BotTriggered -= TryTakeBotPoints;
        }
    }
}
