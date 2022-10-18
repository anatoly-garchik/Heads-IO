using _Scripts.Enemy;
using _Scripts.Factory;
using _Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private GameFactory _gameFactory;
        [SerializeField] private Food.FoodSpawner _foodSpawner;
        
        public override void InstallBindings()
        {
            Container.Bind<IEnemyContainer>().To<EnemyContainer>().AsSingle();
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<GameFactory>().FromInstance(_gameFactory).AsSingle();
            Container.Bind<Food.FoodSpawner>().FromInstance(_foodSpawner).AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }
    }
}
