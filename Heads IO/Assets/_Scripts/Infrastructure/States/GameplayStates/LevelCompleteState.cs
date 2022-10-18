using _Scripts.UI;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States.GameplayStates
{
    public class LevelCompleteState : IState
    {
        private UIAdapter _uiAdapter;
        
        public LevelCompleteState(UIAdapter uiAdapter)
        {
            _uiAdapter = uiAdapter;
        }
        
        public void Enter()
        {
            _uiAdapter.MenuRequested?.Invoke();
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
