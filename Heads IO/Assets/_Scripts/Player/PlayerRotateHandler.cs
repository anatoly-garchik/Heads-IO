using _Scripts.InputService;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerRotateHandler : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _rotationSpeedMultiplier = 3f;
        
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            Vector3 input = _inputService.GetDirection();
            
            if (input.magnitude < 0.1f)
                return;
            
            RotateToTarget(_rotateSpeed * input.normalized);
        }

        private void RotateToTarget(Vector3 destination)
        {
            Quaternion lookRotation = Quaternion.LookRotation(destination);
            Quaternion myRotation = transform.rotation;

            float speedMultiplier = Mathf.Abs(Quaternion.Angle(myRotation, lookRotation));
            float rotationSpeed = 3 * _rotationSpeedMultiplier * speedMultiplier;

            transform.rotation = Quaternion.Slerp(myRotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
