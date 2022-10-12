using _Scripts.Camera;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Player
{
    public class GrowthController : MonoBehaviour
    {
        [SerializeField] private FoodCollector _foodCollector;
        [SerializeField] private Transform _model;
        [SerializeField] private float _maxScaleValue;
        [SerializeField] private CameraFollow _cameraFollow;
        
        private void Awake()
        {
            _foodCollector.EatTaken += IncreaseCharacter;
        }

        public void IncreaseCharacter(float points)
        {
            float scaleFactor = points / 30;
            Vector3 newScale = new Vector3(
                transform.localScale.x + scaleFactor,
                transform.localScale.y + scaleFactor, 
                transform.localScale.z + scaleFactor);


            if (newScale.x < _maxScaleValue)
            {
                transform.localScale = newScale;
                
                if (_cameraFollow != null)
                    _cameraFollow.ChangeOffset(points);
            }
            
            IncreaseAnimation();
        }

        private void IncreaseAnimation()
        {
            _model.DOScaleY(1.5f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                _model.DOScaleY(1, 0.3f).SetEase(Ease.OutBack);
            });
        }

        private void OnDestroy()
        {
            _model.DOKill();
            _foodCollector.EatTaken -= IncreaseCharacter;
        }
    }
}
