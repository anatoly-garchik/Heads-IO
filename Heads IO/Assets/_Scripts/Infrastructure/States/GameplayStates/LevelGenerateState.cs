using _Scripts.Camera;
using _Scripts.Factory;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Infrastructure.States.GameplayStates
{
    public class LevelGenerateState : IState
    {
        private readonly GameFactory _gameFactory;
        
        public bool IsCompleted { get; private set; }

        public LevelGenerateState(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            CameraFollow cameraFollow = UnityEngine.Camera.main.GetComponent<CameraFollow>();
            Player.Player player = _gameFactory.CreatePlayer(Vector3.zero, Quaternion.identity);
            cameraFollow.SetTarget(player);

            IsCompleted = true;
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
