using System.Collections;
using _Scripts.CommonCharacterComponents;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Enemy
{
    public class AgroMode : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField, Range(10, 30)] private int _minTimeToEnableAgroMode;
        [SerializeField, Range(50, 100)] private int _maxTimeToEnableAgroMode;
        
        private Player.Player _player;
        private IEnemyContainer _enemyContainer;

        public Transform TargetForAttack { get; private set; }
        
        [Inject]
        private void Construct(Player.Player player, IEnemyContainer enemyContainer)
        {
            _player = player;
            _enemyContainer = enemyContainer;
        }

        private void Start()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            int waitTime = Random.Range(_minTimeToEnableAgroMode, _maxTimeToEnableAgroMode);
            yield return new WaitForSeconds(waitTime);
            
            TargetForAttack = TryGetTarget();
            StartCoroutine(Timer());
        }

        private Transform TryGetTarget()
        {
            Transform target = null;
            
            foreach (var enemy in _enemyContainer.GetAllEnemy())
            {
                if (enemy.PointsStorage.AmountPoints >= _pointsStorage.AmountPoints) 
                    continue;
                
                target = enemy.transform;
                break;
            }

            if (_player != null && _player.PointsStorage.AmountPoints < _pointsStorage.AmountPoints)
                target = _player.transform;

            return target;
        }
    }
}
