using UnityEngine;

namespace _Scripts.Services.Input
{
    public interface IInputService
    {
        public void SetJoystick(Joystick joystick);
        public Vector3 GetDirection();
    }
}