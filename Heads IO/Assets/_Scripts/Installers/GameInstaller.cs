using _Scripts.Factory;
using _Scripts.Infrastructure;
using _Scripts.Services.Coroutines;
using _Scripts.Services.LoadScene;
using _Scripts.Services.ScreenFade;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _coroutineRunner;
        [SerializeField] private GameObject _screenFade;
        
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromComponentInNewPrefab(_coroutineRunner).AsSingle();
            Container.Bind<IScreenFader>().FromComponentInNewPrefab(_screenFade).AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<GameController>().FromNew().AsSingle();
        }
    }
}
