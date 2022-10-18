using _Scripts.Services.LoadScene;
using _Scripts.UI;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Infrastructure.States.GlobalGameStates
{
    public class MenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly UIAdapter _uiAdapter;
        
        public bool IsGameplayRequested { get; private set; }

        public MenuState(ISceneLoader sceneLoader, UIAdapter uiAdapter)
        {
            _sceneLoader = sceneLoader;
            _uiAdapter = uiAdapter;
        }

        public void Enter()
        {
            _uiAdapter.GameplayRequested += OnGameplayRequested;
            _sceneLoader.LoadScene(SceneNameContainer.Menu, OnMenuLoaded);
        }

        public void Update() { }

        public void Exit()
        {
            _uiAdapter.GameplayRequested -= OnGameplayRequested;
            IsGameplayRequested = false;
        }

        private void OnMenuLoaded()
        {
            
        }

        private void OnGameplayRequested()
        {
            IsGameplayRequested = true;
        }
    }
}