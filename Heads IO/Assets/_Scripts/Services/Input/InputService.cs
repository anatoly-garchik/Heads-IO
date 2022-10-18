using UnityEngine;

namespace _Scripts.Services.Input
{
    public class InputService : IInputService
    {
        private UnityEngine.Camera _mainCamera;
        
        private Joystick _joystick;

        private InputService()
        {
            _mainCamera = UnityEngine.Camera.main;
        }

        public void SetJoystick(Joystick joystick)
        {
            _mainCamera = UnityEngine.Camera.main;
            _joystick = joystick;
        }
        
        public Vector3 GetDirection()
        {
            Vector2 axis = _joystick.Direction;
            Vector3 input = Vector3.zero;
            input.x = axis.x * Mathf.Cos(CameraYOffsetRadians()) + axis.y * Mathf.Sin(CameraYOffsetRadians());
            input.z = -axis.x * Mathf.Sin(CameraYOffsetRadians()) + axis.y * Mathf.Cos(CameraYOffsetRadians());

            return input;
        }
        
        private float CameraYOffsetRadians()
        {
            return Mathf.Deg2Rad * _mainCamera.transform.rotation.eulerAngles.y;
        }
    }
}