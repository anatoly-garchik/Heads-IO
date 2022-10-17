using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.CommonCharacterComponents;
using _Scripts.Enemy;
using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.UI.Leaderboard
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private LeaderboardItem _leaderboardItem;

        private readonly Dictionary<PointsStorage, LeaderboardItem> _items = new Dictionary<PointsStorage, LeaderboardItem>();
        
        private IEnemyContainer _enemyContainer;
        private GameFactory _gameFactory;
        private Player.Player _player;

        [Inject]
        private void Construct(IEnemyContainer enemyContainer, GameFactory gameFactory)
        {
            _enemyContainer = enemyContainer;
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            _player = _gameFactory.Player;
            /*CreateLeaderboard();

            foreach (var enemy in _enemyContainer.GetAllEnemy())
            {
                void DeathAction()
                {
                    enemy.DeathHandler.Died -= DeathAction;
                    TryDeleteItem(enemy.PointsStorage);
                }

                enemy.DeathHandler.Died += DeathAction;
            }*/

            StartCoroutine(Bla());
        }

        private IEnumerator Bla()
        {
            yield return new WaitForSeconds(0.2f);
            
            CreateLeaderboard();

            foreach (var enemy in _enemyContainer.GetAllEnemy())
            {
                void DeathAction()
                {
                    enemy.DeathHandler.Died -= DeathAction;
                    TryDeleteItem(enemy.PointsStorage);
                }

                enemy.DeathHandler.Died += DeathAction;
            }
        } 

        private void Update()
        {
            UpdateLeaderboard();
        }

        private void TryDeleteItem(PointsStorage pointsStorage)
        {
            if (_items.ContainsKey(pointsStorage))
            {
                Destroy(_items[pointsStorage].gameObject);
                _items.Remove(pointsStorage);
            }
        }

        private void UpdateLeaderboard()
        {
            List<KeyValuePair<PointsStorage, LeaderboardItem>> sortItems = _items.OrderByDescending(item => item.Key.AmountPoints).ToList();
            
            for (int i = 0; i < sortItems.Count; i++)
                _items[sortItems[i].Key].UpdateSiblingIndex(i);
        }
        
        private void CreateLeaderboard()
        {
            foreach (var enemy in _enemyContainer.GetAllEnemy())
                CreateItem(false, enemy.PointsStorage);
            
            CreateItem(true, _player.PointsStorage);
        }

        private void CreateItem(bool isPlayerItem, PointsStorage pointsStorage)
        {
            LeaderboardItem item = Instantiate(_leaderboardItem, transform);
            item.Init(isPlayerItem, pointsStorage);
            _items.Add(pointsStorage, item);
        }
    }
}
