using _Scripts.Enemy;
using UnityEngine;
using Zenject;

namespace _Scripts.Factory
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _rangeToSpawnEnemy;
        [SerializeField] private int _amountEnemy;

        private GameFactory _gameFactory;
        private IEnemyContainer _enemyContainer;

        [Inject]
        private void Construct(GameFactory gameFactory, IEnemyContainer enemyContainer)
        {
            _gameFactory = gameFactory;
            _enemyContainer = enemyContainer;
        }
        
        private void Awake()
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
            
            _enemyContainer.AddEnemy(_gameFactory.CreateEnemy(position, Quaternion.identity, transform));
        }
    }
}
