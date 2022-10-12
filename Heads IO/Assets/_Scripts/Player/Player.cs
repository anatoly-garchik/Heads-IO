using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [FormerlySerializedAs("collectorTrigger")] [FormerlySerializedAs("_foodCollector")] [SerializeField] private PlayerCollectorTrigger playerCollectorTrigger;
        [SerializeField] private GrowthController _growthController;

        public float AmountPoints { get; private set; } = 10;

        public event Action Died;
        
        /*private void Awake()
        {
            playerCollectorTrigger.FoodTriggered += AddPoints;
            playerCollectorTrigger.EnemyTriggered += TryTakeEnemyPoints;
        }*/

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

        private void TryTakeEnemyPoints(Bot.Enemy enemy)
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
            playerCollectorTrigger.EnemyTriggered -= TryTakeEnemyPoints;
        }*/
    }
}
