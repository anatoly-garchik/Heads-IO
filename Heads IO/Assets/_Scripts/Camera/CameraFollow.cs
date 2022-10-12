using UnityEngine;

namespace _Scripts.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void FixedUpdate()
        {
            if (_target == null)
                return;

            Vector3 targetPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }

        public void ChangeOffset(float points)
        {
            float bla = points / 25;
            float ofssetY = bla;
            float ofssetz = bla * 2;
            Vector3 newOffset = new Vector3(0, _offset.y + ofssetY, _offset.z - ofssetz);
            _offset = newOffset;
        }
    }
}
