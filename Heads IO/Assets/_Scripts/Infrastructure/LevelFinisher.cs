using _Scripts.Enemy;
using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Infrastructure
{
    public class LevelFinisher : MonoBehaviour
    {
        private IEnemyContainer _enemyContainer;
        private GameFactory _gameFactory;

        private Player.Player _player;
        
        [Inject]
        private void Construct(IEnemyContainer enemyContainer, GameFactory gameFactory)
        {
            _enemyContainer = enemyContainer;
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _player = _gameFactory.Player;
        }

        public bool CheckLevelFinish()
        {
            if (_player == null || _enemyContainer.GetAllEnemy().Count == 0)
                return true;

            return false;
        }
    }
}
