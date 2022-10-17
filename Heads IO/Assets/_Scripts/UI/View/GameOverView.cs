using System;

namespace _Scripts.UI.View
{
    public class GameOverView : View
    {
        public event Action MenuRequested;

        public void LoadMenu()
        {
            MenuRequested?.Invoke();
        }
    }
}
