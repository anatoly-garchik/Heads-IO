using System.Collections.Generic;
using _Scripts.Food;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemyTargetHandler : MonoBehaviour
    {
        [SerializeField] private AgroMode _agroMode;

        private FoodController _foodController;
        private bool _isAgroMode;
        
        public Transform Target { get; private set; }

        [Inject]
        private void Construct(FoodController foodController)
        {
            _foodController = foodController;
        }

        private void Update()
        {
            Target = _agroMode.TargetForAttack;
            
            if (Target == null)
                Target = GetTargetFood();
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
