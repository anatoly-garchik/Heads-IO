using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyMoveHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetHandler _enemyTargetHandler;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        private void Update()
        {
            if (_enemyTargetHandler.Target == null)
                return;
          
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = transform.forward * _speed;
        }
    }
}
