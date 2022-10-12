using System.Collections.Generic;
using _Scripts.Food;
using _Scripts.Player;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemyTargetHandler : MonoBehaviour
    {
        [SerializeField] private EnemyPointsHandler _enemyPoints;

        private PlayerPointsHandler _playerPoints;
        private FoodController _foodController;
        private bool _isAgroMode;
        
        public Transform Target { get; private set; }

        [Inject]
        private void Construct(FoodController foodController,
            PlayerPointsHandler playerPointsHandler)
        {
            _foodController = foodController;
            _playerPoints = playerPointsHandler;
        }

        private void Update()
        {
            if (Target == null)
                Target = GetTargetFood();

            if (_playerPoints == null)
                return;
            
            if (_enemyPoints.AmountPoints > _playerPoints.AmountPoints)
            {
                Target = _playerPoints.transform;
                _isAgroMode = true;
            }
            else if (_enemyPoints.AmountPoints < _playerPoints.AmountPoints && _isAgroMode)
            {
                _isAgroMode = false;
                Target = null;
            }
        }

        private Transform GetTargetFood()
        {
            List<Transform> possibleTargets = _foodController.GetAllFoodItems();

            float distance = Mathf.Infinity;
            Transform closest = null;
            
            foreach (var target in possibleTargets)
            {
                Vector3 different = target.transform.position - transform.position;
                float currentDistance = different.sqrMagnitude;

                if (currentDistance < distance)
                {
                    distance = currentDistance;
                    closest = target.transform;
                }
            }

            return closest;
        }
    }
}
