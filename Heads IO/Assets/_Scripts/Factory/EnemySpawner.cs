using _Scripts.Bot;
using UnityEngine;
using Zenject;

namespace _Scripts.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _rangeToSpawnEnemy;
        [SerializeField] private int _amountEnemy;

        private EnemyFactory _enemyFactory;

        [Inject]
        private void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
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
            
            GameObject enemy = _enemyFactory.CreateEnemy(position, Quaternion.identity, transform);
        }
    }
}
