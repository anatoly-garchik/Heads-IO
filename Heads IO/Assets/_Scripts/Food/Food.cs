using System;
using System.Collections;
using UnityEngine;

namespace _Scripts.Food
{
    public class Food : MonoBehaviour
    {
        private const float MoveSpeed = 10;
        
        [SerializeField] private int _points;

        public int Points => _points;

        public event Action<Food> FoodTaken;

        public void Take(Transform target)
        {
            StartCoroutine(MoveToTarget(target));
        }

        private IEnumerator MoveToTarget(Transform target)
        {
            while (target != null && (target.position - transform.position).sqrMagnitude > 0.2f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, MoveSpeed * Time.deltaTime);
                yield return null;
            }
            
            FoodTaken?.Invoke(this);
        }
    }
}
