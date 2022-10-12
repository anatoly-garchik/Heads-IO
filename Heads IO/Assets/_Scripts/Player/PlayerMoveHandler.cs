using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerMoveHandler : MonoBehaviour
    {
        private float _speedTest = 3;
        
        [SerializeField] private Joystick _joystick;
        [SerializeField] private RotateHandler _rotateHandler;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _destination;
        
        private void Update()
        {
            Vector3 input = _rotateHandler.GetDirection(_joystick.Direction);

            if (input.magnitude < 0.1f)
            {
                _destination = Vector3.zero;
                return;
            }
            
            _rotateHandler.RotateToTarget(_speedTest * _rotateHandler.GetDirection(_joystick.Direction).normalized);

            _destination = _speedTest * input.normalized;
            _rigidbody.velocity = _destination;
        }
    }
}
