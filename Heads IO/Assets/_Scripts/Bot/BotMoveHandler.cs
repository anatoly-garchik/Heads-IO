using System.Collections;
using _Scripts.Factory;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Scripts.Bot
{
    public class BotMoveHandler : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
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
            if (_bot.AmountPoints > _player.AmountPoints)
            {
                //_navMeshAgent.SetDestination(_player.transform.position);
                _target = _player.transform;
            }
            else
            {
                if (_target == null)
                    _target = GetRandomTarget();
            }
            
            transform.LookAt(_target);
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_target.position.x, transform.position.y, _target.position.z), 
                3 * Time.deltaTime);
            
            /*if (_isCanChangeDirection || _navMeshAgent.remainingDistance < 0.5f)
            {
                _navMeshAgent.SetDestination(GetTargetPosition());
                _isCanChangeDirection = false;
                
                if (_timer != null)
                    StopCoroutine(_timer);
                
                _timer = StartCoroutine(DirectionTimer());
            }*/
        }

        private Transform GetRandomTarget()
        {
            return _foodSpawner.GetTargetFood().transform;
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
