using _Scripts.Factory;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.HUD
{
    public class JumpActivatorProgressHandler : MonoBehaviour
    {
        [Header("UI elements")]
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _progressBackground;
        [Header("Jump activator settings")]
        [SerializeField] private int _amountFoodToEnableJump;
        [SerializeField] private int _amountEnemiesToEnableJump;

        private JumpActivator _jumpActivator;
        private GameFactory _gameFactory;
        
        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _jumpActivator = _gameFactory.Player.JumpActivator;
            _jumpActivator.UpdateProgress += UpdateProgress;
            
            UpdateUIElements(0, 0.5f);
        }

        private void UpdateProgress(bool isEnemy)
        {
            if (isEnemy)
                _progressBar.fillAmount += 1 / (float)_amountEnemiesToEnableJump;
            else
                _progressBar.fillAmount += 1 / (float)_amountFoodToEnableJump;

            if (_progressBar.fillAmount >= 1)
                UpdateUIElements(0, 0.5f);
        }

        private void UpdateUIElements(float progressValue, float backgroundAlpha)
        {
            _progressBar.fillAmount = progressValue;
            _progressBackground.color = new Color(1, 1, 1, backgroundAlpha);
        }

        private void OnDestroy()
        {
            _jumpActivator.UpdateProgress -= UpdateProgress;
        }
    }
}
