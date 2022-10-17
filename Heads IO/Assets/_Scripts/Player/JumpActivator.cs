using System;
using System.Collections;
using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Player
{
    public class JumpActivator : MonoBehaviour
    {
        [SerializeField] private float _timeUseJump;
        [SerializeField] private CollectorTrigger _collectorTrigger;

        private int _currentAmountFoodToEnableJump;
        private int _currentAmountEnemiesToEnableJump;

        private Coroutine _routine;

        public event Action<bool> UpdateProgress;
        public event Action<bool> JumpEnabled;
        
        private void Awake()
        {
            _collectorTrigger.FoodTriggered += OnTriggeredFood;
            _collectorTrigger.EnemyTriggered += OnTriggeredEnemy;
        }

        public void ActivateJump()
        {
            _routine = StartCoroutine(EnableJump());
        }

        private void OnTriggeredFood(Food.Food food)
        {
            if (_routine != null) return;
            UpdateProgress?.Invoke(false);
        }

        private void OnTriggeredEnemy(Enemy.Enemy enemy)
        {
            if (_routine != null) return;
            UpdateProgress?.Invoke(true);
        }
        
        private IEnumerator EnableJump()
        {
            JumpEnabled?.Invoke(true);
            
            yield return new WaitForSeconds(_timeUseJump);
            
            _routine = null;
            JumpEnabled?.Invoke(false);
        }

        private void OnDestroy()
        {
            _collectorTrigger.FoodTriggered -= OnTriggeredFood;
            _collectorTrigger.EnemyTriggered -= OnTriggeredEnemy;
        }
    }
}
