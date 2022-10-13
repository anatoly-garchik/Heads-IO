using _Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace _Scripts.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _rangeToSpawnEnemy;
        [SerializeField] private int _amountEnemy;

        private EnemyFactory _enemyFactory;
        private IEnemyContainer _enemyContainer;

        [Inject]
        private void Construct(EnemyFactory enemyFactory, IEnemyContainer enemyContainer)
        {
            _enemyFactory = enemyFactory;
            _enemyContainer = enemyContainer;
        }
        
        private void Start()
        {
            SpawnAllEnemyInStartGame();
        }

        private void SpawnAllEnemyInStartGame()
        {
            for (int i = 0; i < _amountEnemy; i++)
                SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            Vector3 position = new Vector3(Random.Range(-_rangeToSpawnEnemy, _rangeToSpawnEnemy), 0f,
                Random.Range(-_rangeToSpawnEnemy, _rangeToSpawnEnemy));
            
            _enemyContainer.AddEnemy(_enemyFactory.CreateEnemy(position, Quaternion.identity, transform));
        }
    }
}
