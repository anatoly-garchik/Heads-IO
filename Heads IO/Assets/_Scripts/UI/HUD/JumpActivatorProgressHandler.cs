using _Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.UI.HUD
{
    public class JumpActivatorProgressHandler : MonoBehaviour
    {
        /*[Header("UI elements")]
        [SerializeField] private Image _progressBar;
        [SerializeField] private Image _progressBackground;
        [SerializeField] private Button _button;
        [Header("Jump activator settings")]
        [SerializeField] private int _amountFoodToEnableJump;
        [SerializeField] private int _amountEnemiesToEnableJump;

        private JumpActivator _jumpActivator;
        
        [Inject]
        private void Construct(Player.Player player)
        {
            _jumpActivator = player.JumpActivator;
        }
        
        private void Awake()
        {
            _jumpActivator.UpdateProgress += UpdateProgress;
        }

        private void Start()
        {
            UpdateUIElements(0, false, 0.5f);
        }

        public void UseJump()
        {
            _jumpActivator.ActivateJump();
            UpdateUIElements(0, false, 0.5f);
        }

        private void UpdateProgress(bool isEnemy)
        {
            if (isEnemy)
                _progressBar.fillAmount += 1 / (float)_amountEnemiesToEnableJump;
            else
                _progressBar.fillAmount += 1 / (float)_amountFoodToEnableJump;

            if (_progressBar.fillAmount >= 1)
                UpdateUIElements(1, true, 1);
        }

        private void UpdateUIElements(float progressValue, bool isInteractable, float backgroundAlpha)
        {
            _progressBar.fillAmount = progressValue;
            _button.interactable = isInteractable;
            _progressBackground.color = new Color(1, 1, 1, backgroundAlpha);
        }

        private void OnDestroy()
        {
            _jumpActivator.UpdateProgress -= UpdateProgress;
        }*/
    }
}
