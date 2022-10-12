using System.Collections;
using _Scripts.Factory;
using UnityEngine;
using Zenject;

namespace _Scripts.Bot
{
    public class BotMoveHandler : MonoBehaviour
    {
        [SerializeField] private Bot _bot;
        [SerializeField] private int _rangePosition;
        [SerializeField] private int _timeToChangeDirection;
        
        private bool _isCanChangeDirection = true;
        private Coroutine _timer;
        private Player.Player _player;

        private Transform _target;
        [Inject] private FoodSpawner _foodSpawner;


        public void Init(Player.Player player)
        {
            _player = player;
        }
        
        private void Update()
        {
            if (_player != null && _bot.AmountPoints > _player.AmountPoints)
            {
                _target = _player.transform;
            }
            else
            {
                if (_target == null || _player != null && _target == _player.transform)
                    _target = GetRandomTarget();
            }
            
            if (_target == null)
                return;
            
            transform.LookAt(_target);
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_target.position.x, transform.position.y, _target.position.z), 
                3 * Time.deltaTime);
        }

        private Transform GetRandomTarget()
        {
            if (_foodSpawner.GetTargetFood() != null)
                return _foodSpawner.GetTargetFood().transform;

            return null;
        }
        
        
        private Vector3 GetTargetPosition()
        {
            Vector3 targetPosition = new Vector3(Random.Range(-_rangePosition, _rangePosition), 0,
                Random.Range(-_rangePosition, _rangePosition));
            
            return targetPosition;
        }

        private IEnumerator DirectionTimer()
        {
            yield return new WaitForSeconds(_timeToChangeDirection);
            _isCanChangeDirection = true;
        }
    }
}
