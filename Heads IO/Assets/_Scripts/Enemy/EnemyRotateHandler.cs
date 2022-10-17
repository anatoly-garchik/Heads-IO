using UnityEngine;

namespace _Scripts.Enemy
{
    public class EnemyRotateHandler : MonoBehaviour
    {
        [SerializeField] private EnemyTargetHandler _enemyTargetHandler;
        [SerializeField] private Transform _model;
        [SerializeField] private float _rotateSpeedByY;
        [SerializeField] private float _rotateSpeedByX;

        private void Update()
        {
            if (_enemyTargetHandler.Target == null)
                return;
            
            Rotate();
        }

        private void Rotate()
        {
            _model.Rotate(_rotateSpeedByX, 0, 0);
            Vector3 target = _enemyTargetHandler.Target.position - transform.position;
            target.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target), _rotateSpeedByY * Time.deltaTime);
        }
    }
}
