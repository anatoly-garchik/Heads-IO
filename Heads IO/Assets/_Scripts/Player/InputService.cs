using UnityEngine;

namespace _Scripts.Player
{
    public class InputService : IInputService
    {
        private readonly UnityEngine.Camera _mainCamera;
        private readonly Joystick _joystick;

        private InputService(Joystick joystick, UnityEngine.Camera camera)
        {
            _joystick = joystick;
            _mainCamera = camera;
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