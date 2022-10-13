using _Scripts.InputService;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Scripts.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMoveHandler : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Vector3 _destination;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Update()
        {
            Vector3 input = _inputService.GetDirection();

            if (input.magnitude < 0.1f)
            {
                _destination = Vector3.zero;
                _navMeshAgent.velocity = _destination;
                return;
            }

            _destination = _speed * input.normalized;
            
            Move();
        }

        private void Move() =>
            _navMeshAgent.velocity = _destination;
    }
}
