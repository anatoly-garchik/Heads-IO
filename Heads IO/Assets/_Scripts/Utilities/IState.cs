namespace _Scripts.Utilities
{
    public interface IState
    {
        public void Enter();
        public void Update();
        public void Exit();
    }
}