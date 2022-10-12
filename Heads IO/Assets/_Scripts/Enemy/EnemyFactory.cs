using UnityEngine;
using Zenject;

namespace _Scripts.Bot
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private GameObject[] _enemyPrefabs;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public GameObject CreateEnemy(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefab(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], position, rotation, parent);
        }
    }
}
