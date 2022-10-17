using UnityEngine;
using Zenject;

namespace _Scripts.UI.MainMenu
{
    public class GameStarter : MonoBehaviour
    {
        private UIMediator _uiMediator;

        [Inject]
        public void Construct(UIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void StartGame()
        {
            _uiMediator.GameplayRequested?.Invoke();
        }
    }
}
