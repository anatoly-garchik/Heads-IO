using _Scripts.Bot;
using _Scripts.Food;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private FoodFactory _foodFactory;
        [SerializeField] private EnemyFactory _enemyFactory;
        
        public override void InstallBindings()
        {
            Container.Bind<FoodFactory>().FromInstance(_foodFactory).AsSingle();
            Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();
        }
    }
}
