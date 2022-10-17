using System.Collections;
using UnityEngine;

namespace _Scripts.UI.View
{
    public abstract class View : MonoBehaviour, IView
    {
        [SerializeField] private ViewAnimation _viewAnimation;
        [SerializeField] private float _hideTime;
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
            _viewAnimation.Show();
        }

        public virtual void Hide()
        {
            _viewAnimation.Hide();
            gameObject.SetActive(false);
            /*StartCoroutine(Disable());
            
            IEnumerator Disable()
            {
                yield return new WaitForSeconds(_hideTime);
                gameObject.SetActive(false);
            }*/
        }
    }
}
