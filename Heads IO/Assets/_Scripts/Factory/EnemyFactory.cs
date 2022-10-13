using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy[] _enemyPrefabs;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public Enemy CreateEnemy(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefabForComponent<Enemy>(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], position, rotation, parent);
        }
    }
}
