using UnityEngine;

namespace _Scripts.Player
{
    public class RotateHandler : MonoBehaviour
    {
        private const float RotateTime = 0.2f;
        
        [SerializeField] private float _rotationSpeedMultiplier = 3f;
        
        private UnityEngine.Camera _mainCamera;

		
        private void Awake()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        private void OnDisable()
        {
            transform.localEulerAngles = Vector3.zero;
        }

        public Vector3 GetDirection(Vector2 axis)
        {
            Vector3 input = Vector3.zero;
            input.x = axis.x * Mathf.Cos(CameraYOffsetRadians()) + axis.y * Mathf.Sin(CameraYOffsetRadians());
            input.z = -axis.x * Mathf.Sin(CameraYOffsetRadians()) + axis.y * Mathf.Cos(CameraYOffsetRadians());

            return input;
        }
        
        private float CameraYOffsetRadians()
        {
            return Mathf.Deg2Rad * _mainCamera.transform.rotation.eulerAngles.y;
        }
        
        public void RotateToTarget(Vector3 destination)
        {
            Quaternion lookRotation = Quaternion.LookRotation(destination);
            Quaternion myRotation = transform.rotation;

            float speedMultiplier = Mathf.Abs(Quaternion.Angle(myRotation, lookRotation));
            float rotationSpeed = 3 * _rotationSpeedMultiplier * speedMultiplier;

            transform.rotation = Quaternion.Slerp(myRotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        
        public float Remap(float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}
