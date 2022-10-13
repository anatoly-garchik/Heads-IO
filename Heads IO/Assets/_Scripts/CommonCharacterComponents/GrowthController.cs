using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.CommonCharacterComponents
{
    public class GrowthController : MonoBehaviour
    {
        private const float AnimationTime = 0.3f;
        
        [SerializeField] private Transform _model;
        [SerializeField] private float _maxScaleValue;
        [SerializeField] private float _scaleFactor;

        public event Action<float> ScaleIncreased;
        
        public void IncreaseCharacter(float points)
        {
            float scaleFactor = points / _scaleFactor;
            
            Vector3 newScale = new Vector3(
                transform.localScale.x + scaleFactor,
                transform.localScale.y + scaleFactor, 
                transform.localScale.z + scaleFactor);


            if (newScale.x < _maxScaleValue)
            {
                transform.localScale = newScale;
                ScaleIncreased?.Invoke(points);
            }
            
            IncreaseAnimation();
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
            _model.DOKill();
        }
    }
}
