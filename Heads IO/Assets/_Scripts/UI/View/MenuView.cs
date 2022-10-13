using Zenject;

namespace _Scripts.UI.View
{
    public class MenuView : View
    {
        private ViewManager _viewManager;

        [Inject]
        private void Construct(ViewManager viewManager)
        {
            _viewManager = viewManager;
        }

        public void StartGame()
        {
            _viewManager.ShowView<GameplayView>();
        }
    }
}
