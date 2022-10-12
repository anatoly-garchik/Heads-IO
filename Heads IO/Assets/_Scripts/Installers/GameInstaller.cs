using _Scripts.Food;
using _Scripts.Player;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private FoodController _foodController;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerPointsHandler _playerPointsHandler;
        [SerializeField] private UnityEngine.Camera _mainCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<FoodController>().FromInstance(_foodController).AsSingle();
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<PlayerPointsHandler>().FromInstance(_playerPointsHandler).AsSingle();
            Container.Bind<UnityEngine.Camera>().FromInstance(_mainCamera).AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }
    }
}
