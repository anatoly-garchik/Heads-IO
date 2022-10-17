using _Scripts.Enemy;
using _Scripts.Food;
using _Scripts.Services.Input;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        //[SerializeField] private FoodSpawner foodSpawner;
        [SerializeField] private Joystick _joystick;
        //[SerializeField] private Player.Player _player;
        
        public override void InstallBindings()
        {
            //Container.Bind<FoodSpawner>().FromInstance(foodSpawner).AsSingle();
            Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
            //Container.Bind<Player.Player >().FromInstance(_player).AsSingle();
            
           // Container.Bind<IEnemyContainer>().To<EnemyContainer>().AsSingle();
        }
    }
}
