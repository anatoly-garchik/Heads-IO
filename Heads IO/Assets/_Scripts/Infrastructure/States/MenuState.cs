using _Scripts.Services.LoadScene;
using _Scripts.Utilities;

namespace _Scripts.Infrastructure.States
{
    public class MenuState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(SceneNameContainer.Menu, null);
        }

        public void Update() { }

        public void Exit() { }
    }
}