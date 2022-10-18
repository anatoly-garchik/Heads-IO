using _Scripts.CommonCharacterComponents;
using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Enemy
{
    public class SkullMarkHandler : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField] private GameObject _skullMark;
        
        private Player.Player _player;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _player = gameFactory.Player;
        }
        
        /*public void SetTarget(Player.Player player)
        {
            _player = player;
        }*/

        private void Update()
        {
            if (_player.PointsStorage.AmountPoints >= _pointsStorage.AmountPoints)
                if (_skullMark.activeSelf)
                    _skullMark.SetActive(false);
            
            if (_player.PointsStorage.AmountPoints < _pointsStorage.AmountPoints)
                if (!_skullMark.activeSelf)
                    _skullMark.SetActive(true);
        }
    }
}
