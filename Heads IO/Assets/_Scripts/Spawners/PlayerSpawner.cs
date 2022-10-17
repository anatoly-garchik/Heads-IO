using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Spawners
{
    public class PlayerSpawner : MonoBehaviour
    {
        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _gameFactory.CreatePlayer(Vector3.zero, Quaternion.identity, transform);
        }
    }
}
