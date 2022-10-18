using _Scripts.Enemy;
using _Scripts.Factory;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Infrastructure.States.GameplayStates
{
    public class LevelSpawnOpponentsState : IState
    {
        private const float RangeToSpawnEnemy = 25;
        private const int AmountEnemy = 10;

        private readonly GameFactory _gameFactory;
        private readonly IEnemyContainer _enemyContainer;
        
        public bool HasSpawnedOpponents { get; private set; }
        
        public LevelSpawnOpponentsState(GameFactory gameFactory, IEnemyContainer enemyContainer)
        {
            _gameFactory = gameFactory;
            _enemyContainer = enemyContainer;
        }

        public void Enter()
        {
            _enemyContainer.ClearEnemyContainer();
            
            for (int i = 0; i < AmountEnemy; i++)
                SpawnEnemy();

            HasSpawnedOpponents = true;
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
        
        private void SpawnEnemy()
        {
            Vector3 position = new Vector3(Random.Range(-RangeToSpawnEnemy, RangeToSpawnEnemy), 0f,
                Random.Range(-RangeToSpawnEnemy, RangeToSpawnEnemy));
            
            _enemyContainer.AddEnemy(_gameFactory.CreateEnemy(position, Quaternion.identity));
        }
    }
}
