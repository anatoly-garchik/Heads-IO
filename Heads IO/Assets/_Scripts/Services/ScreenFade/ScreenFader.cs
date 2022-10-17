using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Services.ScreenFade
{
    public class ScreenFader : MonoBehaviour, IScreenFader
    {
        [SerializeField] private float _duration;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Ease _ease;

        private Tween _tweenFade;
        
        public void ShowCurtain(Action onComplete = null)
        {
            StopFade();
            
            _canvas.enabled = true;
            _canvasGroup.alpha = 0;
            
            _tweenFade = _canvasGroup.DOFade(1, _duration).SetEase(_ease).OnComplete(() =>
            {
                OnShowScreen();
                onComplete?.Invoke();
            });
        }

        public void ShowCurtainImmediate()
        {
            StopFade();
            OnShowScreen();
        }

        public void HideCurtain(Action onComplete = null)
        {
            StopFade();
            
            _canvas.enabled = true;
            _canvasGroup.alpha = 1;
            
            _tweenFade = _canvasGroup.DOFade(0, _duration).SetEase(_ease).OnComplete(() =>
            {
                OnHideScreen();
                onComplete?.Invoke();
            });
        }

        public void HideCurtainImmediate()
        {
            StopFade();
            OnHideScreen();
        }

        private void StopFade()
        {
            _tweenFade?.Complete();
        }

        private void OnShowScreen()
        {
            _canvas.enabled = true;
            _canvasGroup.alpha = 1;
        }

        private void OnHideScreen()
        {
            _canvas.enabled = false;
        }
    }
}

