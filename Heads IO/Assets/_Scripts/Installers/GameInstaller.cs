using _Scripts.Factory;
using _Scripts.Infrastructure;
using _Scripts.Services.Coroutines;
using _Scripts.Services.LoadScene;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _coroutineRunner;
        
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>().FromComponentInNewPrefab(_coroutineRunner).AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<GameController>().FromNew().AsSingle();
        }
    }
}
