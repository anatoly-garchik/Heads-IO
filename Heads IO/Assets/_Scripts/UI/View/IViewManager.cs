namespace _Scripts.UI.View
{
    public interface IViewManager
    {
        public T View<T>() where T : IView;
        public void Show<T>() where T : IView;
        public void Hide<T>() where T : IView;
    }
}
