using System.Collections;
using _Scripts.Services.Coroutines;
using UnityEngine;

namespace _Scripts.Utilities
{
    public class SelRunningStateMachine : StateMachine
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        private Coroutine _coroutine;

        protected SelRunningStateMachine(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        
        public void Run()
        {
            if (_coroutine != null)
                return;

            _coroutine = _coroutineRunner.StartCoroutine(UpdateRoutine());
        }

        public void Stop()
        {
            if (_coroutine == null)
                return;
            
            _coroutineRunner.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator UpdateRoutine()
        {
            while (true)
            {
                Update();
                yield return null;
            }
        }
    }
}