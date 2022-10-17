using _Scripts.Services.LoadScene;
using _Scripts.UI.View;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States
{
    public class MenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IViewManager _viewManager;
        
        public bool IsGameplayRequested { get; private set; }

        public MenuState(ISceneLoader sceneLoader, IViewManager viewManager)
        {
            _sceneLoader = sceneLoader;
            _viewManager = viewManager;
        }

        public void Enter()
        {
            _viewManager.View<MenuView>().GameplayRequested += OnGameplayRequested;
            _sceneLoader.LoadScene(SceneNameContainer.Menu, OnMenuLoaded);
        }

        public void Update() { }

        public void Exit()
        {
            _viewManager.View<MenuView>().GameplayRequested -= OnGameplayRequested;
            IsGameplayRequested = false;
        }

        private void OnMenuLoaded()
        {
            _viewManager.Show<MenuView>();
        }

        private void OnGameplayRequested()
        {
            IsGameplayRequested = true;
        }
    }
}