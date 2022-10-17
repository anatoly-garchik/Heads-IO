using _Scripts.Factory;
using _Scripts.Infrastructure.States.GameplayStates;
using _Scripts.UI;
using _Scripts.Utilities;
using UnityEngine;
using Zenject;

namespace _Scripts.Infrastructure
{
    public class GameplayController : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Construct(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        private void Start()
        {
            _stateMachine = CreateGameplayStateMachine();
        }

        private void Update()
        {
            _stateMachine.Update();
        }

        private StateMachine CreateGameplayStateMachine()
        {
            StateMachine stateMachine = new StateMachine();
            
            LevelGenerateState levelGenerate = _stateFactory.CreateState<LevelGenerateState>();
            LevelSpawnOpponentsState levelSpawnOpponents = _stateFactory.CreateState<LevelSpawnOpponentsState>();
            LevelPlayState levelPlay = _stateFactory.CreateState<LevelPlayState>();
            LevelCompleteState levelComplete = _stateFactory.CreateState<LevelCompleteState>();

            stateMachine.AddTransition(levelGenerate, levelSpawnOpponents, () => levelGenerate.IsCompleted);
            stateMachine.AddTransition(levelSpawnOpponents, levelPlay, () => levelSpawnOpponents.HasSpawnedOpponents);
            //stateMachine.AddTransition(levelPlay, levelComplete, () => IsPlayerDead() || OneBlobLeft());

            stateMachine.SetState(levelGenerate);
            
            return stateMachine;
        }

        private void OnDestroy()
        {
            _stateMachine?.CurrentState?.Exit();
        }
    }
}
