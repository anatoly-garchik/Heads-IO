using UnityEngine;
using UnityEngine.AI;

namespace _Scripts.Enemy
{
    public class EnemyMoveHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetHandler _enemyTargetHandler;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _speed;
        
        private void Update()
        {
            if (_enemyTargetHandler.Target == null)
                return;
          
            Move();
        }

        private void Move()
        {
            _navMeshAgent.velocity = transform.forward * _speed;
        }
    }
}
