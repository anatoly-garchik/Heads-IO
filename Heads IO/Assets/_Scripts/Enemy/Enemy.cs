using System;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Bot
{
    public class Enemy : MonoBehaviour
    {
        [FormerlySerializedAs("collectorTrigger")] [FormerlySerializedAs("_foodCollector")] [SerializeField] private PlayerCollectorTrigger playerCollectorTrigger;
        [SerializeField] private GrowthController _growthController;

        public float AmountPoints { get; private set; } = 1;

        private void Awake()
        {
            /*playerCollectorTrigger.FoodTriggered += AddPoints;
            playerCollectorTrigger.PlayerTriggered += TryTakePlayerPoints;
            playerCollectorTrigger.EnemyTriggered += TryTakeEnemyPoints;*/
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
        private void TryTakeEnemyPoints(Enemy enemy)
        {
            if (enemy.AmountPoints < AmountPoints)
            {
                AddPoints(enemy.AmountPoints);
                _growthController.IncreaseCharacter(enemy.AmountPoints);
                Destroy(enemy.gameObject);
            }
        }
        

        /*private void OnDestroy()
        {
            playerCollectorTrigger.FoodTriggered -= AddPoints;
            playerCollectorTrigger.PlayerTriggered -= TryTakePlayerPoints;
            playerCollectorTrigger.EnemyTriggered -= TryTakeEnemyPoints;
        }*/
    }
}
