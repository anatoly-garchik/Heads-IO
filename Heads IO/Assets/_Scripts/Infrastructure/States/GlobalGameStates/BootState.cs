using _Scripts.Services.ScreenFade;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States.GlobalGameStates
{
    public class BootState : IState
    {
        private readonly IScreenFader _screenFader;

        public bool IsBootStateLoaded { get; private set; }
        
        public BootState(IScreenFader screenFader)
        {
            _screenFader = screenFader;
        }

        public void Enter()
        {
            _screenFader.ShowCurtainImmediate();
            IsBootStateLoaded = true;
        }

        public void Update() { }

        public void Exit() { }
    }
}
