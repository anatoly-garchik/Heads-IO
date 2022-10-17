using _Scripts.Factory;
using _Scripts.Infrastructure.States.GameplayStates;
using _Scripts.Services.Input;
using _Scripts.Utilities;
using UnityEngine;
using Zenject;
using FoodSpawner = _Scripts.Food.FoodSpawner;

namespace _Scripts.Infrastructure
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private FoodSpawner _foodSpawner;
        
        private StateMachine _stateMachine;
        private IStateFactory _stateFactory;

        [Inject]
        private void Construct(IStateFactory stateFactory, Joystick joystick, IInputService inputService)
        {
            _stateFactory = stateFactory;
            inputService.SetJoystick(joystick);
        }

        private void Awake()
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
            
            levelSpawnOpponents.SetEnemyLinks(_foodSpawner);

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
