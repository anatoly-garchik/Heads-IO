using System;
using System.Collections.Generic;

namespace _Scripts.Utilities
{
    public class StateMachine
    {
        private static readonly List<Transition> s_emptyTransitions = new List<Transition>(0);

        private Dictionary<Type, List<Transition>> _transitionByStateType;
        private List<Transition> _currentTransitions;
        
        public IState CurrentState { get; private set; }

        public StateMachine()
        {
            _transitionByStateType = new Dictionary<Type, List<Transition>>();
            _currentTransitions = new List<Transition>();
        }

        public void Update()
        {
            if (TryGetTransition(out Transition transition))
                SetState(transition.State);
            
            CurrentState?.Update();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            Type stateType = from.GetType();

            if (!_transitionByStateType.ContainsKey(stateType))
                _transitionByStateType.Add(stateType, new List<Transition>());
            
            _transitionByStateType[stateType].Add(new Transition(to, condition));
        }

        public void SetState(IState state)
        {
            if (CurrentState == state)
                return;
            
            CurrentState?.Exit();
            CurrentState = state;
            _currentTransitions = GetTransitions(CurrentState);
            CurrentState.Enter();
        }

        private bool TryGetTransition(out Transition transition)
        {
            foreach (var currentTransition in _currentTransitions)
            {
                if (currentTransition.Condition())
                {
                    transition = currentTransition;
                    return true;
                }
            }

            transition = null;
            return false;
        }

        private List<Transition> GetTransitions(IState state)
        {
            Type stateType = state.GetType();

            return _transitionByStateType.ContainsKey(stateType) ? 
                _transitionByStateType[stateType] : s_emptyTransitions;
        }
    }
}
