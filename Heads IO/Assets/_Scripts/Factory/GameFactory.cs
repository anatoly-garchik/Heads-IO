using UnityEngine;
using Zenject;

namespace _Scripts.Factory
{
    public class GameFactory : MonoBehaviour, IGameFactory
    {
        [SerializeField] private Food.Food[] _foods; 
        [SerializeField] private Enemy.Enemy[] _enemies;
        [SerializeField] private Player.Player _player;
            
        private DiContainer _diContainer;
        
        public Player.Player Player { get; private set; }

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Player.Player CreatePlayer(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Player = _diContainer.InstantiatePrefabForComponent<Player.Player>(_player, position, rotation, parent);
            return Player;
        }
        
        public Food.Food CreateFood(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefabForComponent<Food.Food>(_foods[Random.Range(0, _foods.Length)], position, rotation, parent);
        }
        
        public Enemy.Enemy CreateEnemy(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefabForComponent<Enemy.Enemy>(_enemies[Random.Range(0, _enemies.Length)], position, rotation, parent);
        }
    }

    public interface IGameFactory
    {
        public Player.Player CreatePlayer(Vector3 position, Quaternion rotation, Transform parent = null);
        public Food.Food CreateFood(Vector3 position, Quaternion rotation, Transform parent = null);
        public Enemy.Enemy CreateEnemy(Vector3 position, Quaternion rotation, Transform parent = null);
    }
}
