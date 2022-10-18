using UnityEngine;
using Zenject;

namespace _Scripts.UI.MainMenu
{
    public class GameStarter : MonoBehaviour
    {
        private UIAdapter _uiAdapter;

        [Inject]
        public void Construct(UIAdapter uiAdapter)
        {
            _uiAdapter = uiAdapter;
        }

        public void StartGame()
        {
            _uiAdapter.GameplayRequested?.Invoke();
        }
    }
}
