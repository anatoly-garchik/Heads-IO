using _Scripts.Services.LoadScene;
using _Scripts.UI;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Infrastructure.States.GlobalGameStates
{
    public class MenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly UIMediator _uiMediator;
        
        public bool IsGameplayRequested { get; private set; }

        public MenuState(ISceneLoader sceneLoader, UIMediator uiMediator)
        {
            _sceneLoader = sceneLoader;
            _uiMediator = uiMediator;
            Debug.Log(_uiMediator);
        }

        public void Enter()
        {
            _uiMediator.GameplayRequested += OnGameplayRequested;
            _sceneLoader.LoadScene(SceneNameContainer.Menu, OnMenuLoaded);
        }

        public void Update() { }

        public void Exit()
        {
            _uiMediator.GameplayRequested -= OnGameplayRequested;
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