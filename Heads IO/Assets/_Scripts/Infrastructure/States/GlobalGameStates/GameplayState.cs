using _Scripts.Services.LoadScene;
using _Scripts.UI;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States.GlobalGameStates
{
    public class GameplayState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private UIAdapter _uiAdapter;
        
        public bool IsMenuRequested { get; private set; }

        public GameplayState(ISceneLoader sceneLoader, UIAdapter uiAdapter)
        {
            _sceneLoader = sceneLoader;
            _uiAdapter = uiAdapter;
        }

        public void Enter()
        {
            _uiAdapter.MenuRequested += OnMenuRequested;
            _sceneLoader.LoadScene(SceneNameContainer.Gameplay, null);
        }

        public void Update() { }

        public void Exit()
        {
            _uiAdapter.MenuRequested -= OnMenuRequested;
            IsMenuRequested = false;
        }

        private void OnMenuRequested()
        {
            IsMenuRequested = true;
        }
    }
}