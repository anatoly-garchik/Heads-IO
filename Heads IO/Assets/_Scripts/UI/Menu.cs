using _Scripts.Enemy;
using _Scripts.UI.View;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class Menu : MonoBehaviour
    {
        private ViewManager _viewManager;
        private IEnemyContainer _enemyContainer;
        private Player.Player _player;
        
        [Inject]
        private void Construct(ViewManager viewManager,
            IEnemyContainer enemyContainer,
            Player.Player player)
        {
            _viewManager = viewManager;
            _enemyContainer = enemyContainer;
            _player = player;
        }

        private void Awake()
        {
            _enemyContainer.EnemyRemoved += CheckEnemyAmount;
            _player.DeathHandler.Died += OnDiedPlayer;
        }

        private void Start()
        {
            _viewManager.ShowView<GameplayView>();
        }

        private void CheckEnemyAmount()
        {
            if (_enemyContainer.GetAllEnemy().Count == 0)
                _viewManager.ShowView<GameOverView>();
        }

        private void OnDiedPlayer()
        {
            _viewManager.ShowView<GameOverView>();
        }

        private void OnDestroy()
        {
            _enemyContainer.EnemyRemoved -= CheckEnemyAmount;
            _player.DeathHandler.Died -= OnDiedPlayer;
        }
    }
}
