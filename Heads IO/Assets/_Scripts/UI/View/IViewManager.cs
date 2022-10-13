namespace _Scripts.UI.View
{
    public interface IViewManager
    {
        public void ShowView<T>() where T : IView;
        public void HideView<T>() where T : IView;
    }
}
