using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Distance settings ")]
        [SerializeField] private GrowthController _playerGrowthController;
        [SerializeField] private float _remoteFactor;
        [Header("Follow settings")]
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            //_playerGrowthController.ScaleIncreased += ChangeOffset;
        }

        private void LateUpdate()
        {
            if (_target == null)
                return;

            Vector3 targetPosition = _target.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }

        private void ChangeOffset(float points)
        {
            float offset = points / _remoteFactor;
            float newYOffset = offset;
            float newZOffset = offset * 2;
            
            Vector3 newOffset = new Vector3(0, _offset.y + newYOffset, _offset.z - newZOffset);
            _offset = newOffset;
        }

        private void OnDestroy()
        {
            //_playerGrowthController.ScaleIncreased -= ChangeOffset;
        }
    }
}
