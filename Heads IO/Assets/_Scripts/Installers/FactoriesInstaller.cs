using _Scripts.Enemy;
using _Scripts.Factory;
using _Scripts.Food;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        /*[SerializeField] private FoodFactory _foodFactory;
        [SerializeField] private EnemyFactory _enemyFactory;*/
        [SerializeField] private GameFactory _gameFactory;
        
        public override void InstallBindings()
        {
            Container.Bind<GameFactory>().FromInstance(_gameFactory).AsSingle();
            /*Container.Bind<FoodFactory>().FromInstance(_foodFactory).AsSingle();
            Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();*/
            //Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }
    }
}
