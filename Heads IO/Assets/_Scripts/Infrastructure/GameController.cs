using _Scripts.Factory;
using _Scripts.Infrastructure.States;
using _Scripts.Services.Coroutines;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure
{
    public class GameController : SelRunningStateMachine
    {
        public GameController(IStateFactory stateFactory, ICoroutineRunner coroutineRunner) : base(coroutineRunner)
        {
            BootState bootState = stateFactory.CreateState<BootState>();
            MenuState menuState = stateFactory.CreateState<MenuState>();
            GameplayState gameplayState = stateFactory.CreateState<GameplayState>();
            
            /*AddTransition(bootState, menuState, );
            AddTransition(menuState, gameplayState, );
            AddTransition(gameplayState, menuState, );*/
            
            SetState(bootState);
        }
    }
}