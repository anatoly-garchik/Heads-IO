using _Scripts.Services.LoadScene;
using _Scripts.UI.View;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly IViewManager _viewManager;
        private readonly ISceneLoader _sceneLoader;
        
        public bool IsMenuRequested { get; private set; }

        public GameplayState(ISceneLoader sceneLoader, IViewManager viewManager)
        {
            _sceneLoader = sceneLoader;
            _viewManager = viewManager;
        }

        public void Enter()
        {
            _viewManager.View<GameOverView>().MenuRequested += OnMenuRequested;
            _viewManager.Show<GameplayView>();
            _sceneLoader.LoadScene(SceneNameContainer.Gameplay, null);
        }

        public void Update() { }

        public void Exit()
        {
            _viewManager.View<GameOverView>().MenuRequested -= OnMenuRequested;
            IsMenuRequested = false;
        }

        private void OnMenuRequested()
        {
            IsMenuRequested = true;
        }
    }
}