using System;
using System.Collections;
using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Player
{
    public class JumpActivator : MonoBehaviour
    {
        [SerializeField] private float _timeUseJump;
        [SerializeField] private int _amountFoodToEnableJump;
        [SerializeField] private int _amountEnemiesToEnableJump;
        [SerializeField] private CollectorTrigger _collectorTrigger;

        private int _currentAmountFoodToEnableJump;
        private int _currentAmountEnemiesToEnableJump;
        private bool _isEnableJump;
        
        public event Action<bool> JumpEnabled;
        
        private void Awake()
        {
            _collectorTrigger.FoodTriggered += OnTriggeredFood;
            _collectorTrigger.EnemyTriggered += OnTriggeredEnemy;
        }

        private void OnTriggeredFood(Food.Food food)
        {
            if (_isEnableJump)
                return;
            
            _currentAmountFoodToEnableJump++;

            if (_currentAmountFoodToEnableJump < _amountFoodToEnableJump) 
                return;
            
            StartCoroutine(EnableJump());
        }

        private void OnTriggeredEnemy(Enemy.Enemy enemy)
        {
            if (_isEnableJump)
                return;

            _currentAmountEnemiesToEnableJump++;
            
            if (_currentAmountEnemiesToEnableJump < _amountEnemiesToEnableJump) 
                return;
            
            StartCoroutine(EnableJump());
        }
        
        private IEnumerator EnableJump()
        {
            _isEnableJump = true;
            JumpEnabled?.Invoke(_isEnableJump);
            
            yield return new WaitForSeconds(_timeUseJump);
            
            _currentAmountEnemiesToEnableJump = 0;
            _currentAmountFoodToEnableJump = 0;
            JumpEnabled?.Invoke(false);
        }

        private void OnDestroy()
        {
            _collectorTrigger.FoodTriggered -= OnTriggeredFood;
            _collectorTrigger.EnemyTriggered -= OnTriggeredEnemy;
        }
    }
}
