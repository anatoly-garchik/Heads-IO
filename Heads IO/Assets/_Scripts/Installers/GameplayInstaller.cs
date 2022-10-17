using _Scripts.Enemy;
using _Scripts.Food;
using _Scripts.Services.Input;
using _Scripts.UI.View;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private FoodController _foodController;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Player.Player _player;
        [SerializeField] private UnityEngine.Camera _mainCamera;
        [SerializeField] private ViewManager _viewManager;
        
        public override void InstallBindings()
        {
            Container.Bind<FoodController>().FromInstance(_foodController).AsSingle();
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            Container.Bind<Player.Player >().FromInstance(_player).AsSingle();
            Container.Bind<UnityEngine.Camera>().FromInstance(_mainCamera).AsSingle();
            Container.Bind<ViewManager>().FromInstance(_viewManager).AsSingle();
            
            //Container.Bind<IViewManager>().FromComponentInNewPrefab(_ui).AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IEnemyContainer>().To<EnemyContainer>().AsSingle();
        }
    }
}
