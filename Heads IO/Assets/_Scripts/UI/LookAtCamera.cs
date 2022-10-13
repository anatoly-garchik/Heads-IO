using UnityEngine;

namespace _Scripts.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
		
        private UnityEngine.Camera _mainCamera;
		
        private void Awake()
        {
            _mainCamera = UnityEngine.Camera.main;
            
            if (_canvas)
                _canvas.worldCamera = _mainCamera;
        }

        private void Update() 
        {
            transform.LookAt(_mainCamera.transform.position, Vector3.up);
        }

        private void LateUpdate()
        {
            transform.forward = _mainCamera.transform.forward;
        }
    }
}
