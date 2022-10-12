using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Player.Player _player;
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _player.Died += ShowLoseScreen;
        }

        private void ShowLoseScreen()
        {
            _restartButton.gameObject.SetActive(true);
            _restartButton.image.DOFade(0.5f, 0.3f);
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(0);
        }

        private void OnDestroy()
        {
            _player.Died -= ShowLoseScreen;
        }
    }
}
