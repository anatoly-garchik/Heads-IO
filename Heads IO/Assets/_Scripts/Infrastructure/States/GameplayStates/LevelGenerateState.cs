using _Scripts.Factory;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Infrastructure.States.GameplayStates
{
    public class LevelGenerateState : IState
    {
        private GameFactory _gameFactory;
        
        public bool IsCompleted { get; private set; }

        public LevelGenerateState(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            //_gameFactory.CreatePlayer(Vector3.zero, Quaternion.identity);
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
