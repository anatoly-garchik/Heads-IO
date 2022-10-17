using System;

namespace _Scripts.UI.View
{
    public class MenuView : View
    {
        public event Action GameplayRequested;

        public void StartGame()
        {
            GameplayRequested?.Invoke();
        }
    }
}
