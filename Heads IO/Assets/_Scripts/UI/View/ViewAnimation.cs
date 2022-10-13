using DG.Tweening;
using UnityEngine;

namespace _Scripts.UI.View
{
    public class ViewAnimation : MonoBehaviour
    {
        [SerializeField] private DOTweenAnimation[] _doTweenAnimations;
        
        public void Show()
        {
            foreach (var tweenAnimation in _doTweenAnimations)
            {
                tweenAnimation.DORestart();
            }
        }

        public void Hide()
        {
            foreach (var tweenAnimation in _doTweenAnimations)
            {
                tweenAnimation.DOPlayBackwards();
            }
        }
    }
}