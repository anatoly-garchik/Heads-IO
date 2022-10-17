using _Scripts.Utilities;
using Zenject;

namespace _Scripts.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _diContainer;

        public StateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T CreateState<T>() where T : IState
        {
            return _diContainer.Instantiate<T>();
        }
    }

    public interface IStateFactory
    {
        public T CreateState<T>() where T : IState;
    }
}