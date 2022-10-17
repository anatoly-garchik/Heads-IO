using _Scripts.Enemy;
using _Scripts.Factory;
using _Scripts.Infrastructure;
using _Scripts.Services.Coroutines;
using _Scripts.Services.Input;
using _Scripts.Services.LoadScene;
using _Scripts.Services.ScreenFade;
using _Scripts.UI;
using _Scripts.UI.View;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _coroutineRunner;
        [SerializeField] private GameObject _screenFade;
        [SerializeField] private GameObject _ui;
        
        public override void InstallBindings()
        {
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<GameController>().FromNew().AsSingle();

            Container.Bind<UIMediator>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IEnemyContainer>().To<EnemyContainer>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromComponentInNewPrefab(_coroutineRunner).AsSingle();
            Container.Bind<IScreenFader>().FromComponentInNewPrefab(_screenFade).AsSingle();
            //Container.Bind<IViewManager>().FromComponentInNewPrefab(_ui).AsSingle();
        }
    }
}
