using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyRotateHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetHandler _enemyTargetHandler;
        [SerializeField] private float _rotateSpeed;

        private void Update()
        {
            if (_enemyTargetHandler.Target == null)
                return;
            
            Rotate();
        }

        private void Rotate()
        {
            Vector3 target = _enemyTargetHandler.Target.position - transform.position;
            target.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target), _rotateSpeed * Time.deltaTime);
        }
    }
}
