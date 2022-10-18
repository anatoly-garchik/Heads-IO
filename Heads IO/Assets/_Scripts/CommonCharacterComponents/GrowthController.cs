using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.CommonCharacterComponents
{
    public class GrowthController : MonoBehaviour
    {
        private const float AnimationTime = 0.3f;

        [SerializeField] private SphereCollider _sphereCollider;
        [SerializeField] private Transform _modelPivot;
        [SerializeField] private Transform _model;
        [SerializeField] private Transform _canvas;
        [SerializeField] private float _maxScaleValue;
        [SerializeField] private float _scaleFactor;

        public event Action<float> ScaleIncreased;
        
        public void IncreaseCharacter(float points)
        {
            float scaleFactor = points / _scaleFactor;

            UpdateModel(points, scaleFactor);
            UpdateCanvas(scaleFactor);
            UpdateCollider(scaleFactor);

            IncreaseAnimation();
        }

        private void UpdateModel(float points, float scaleFactor)
        {
            Vector3 newScale = new Vector3(
                _modelPivot.localScale.x + scaleFactor,
                _modelPivot.localScale.y + scaleFactor, 
                _modelPivot.localScale.z + scaleFactor);


            if (!(newScale.x < _maxScaleValue)) return;
            
            _modelPivot.localScale = newScale;
            ScaleIncreased?.Invoke(points);
        }

        private void UpdateCanvas(float scaleFactor)
        {
            if (_canvas != null) 
                _canvas.transform.position = new Vector3(_canvas.transform.position.x, _canvas.transform.position.y + scaleFactor, _canvas.transform.position.z);
        }

        private void UpdateCollider(float scaleFactor)
        {
            _sphereCollider.radius += scaleFactor / 2;
            _sphereCollider.center = new Vector3(0, _sphereCollider.radius, 0);
        }

        private void IncreaseAnimation()
        {
            _model.DOScaleY(1.5f, AnimationTime).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                _model.DOScaleY(1, AnimationTime).SetEase(Ease.OutBounce);
            });
        }

        private void OnDestroy()
        {
            transform.DOKill();
            _model.DOKill();
        }
    }
}
