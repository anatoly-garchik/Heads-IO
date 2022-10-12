using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private FoodSpawner _foodSpawner;
        
        public override void InstallBindings()
        {
            Container.Bind<FoodSpawner>().FromInstance(_foodSpawner).AsSingle();
        }
    }
}
