using System.Collections;
using _Scripts.Audio;
using _Scripts.Services.Input;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerMoveHandler : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [Header("Jump settings")]
        [SerializeField] private JumpActivator _jumpActivator;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private float _jumpDuration;
        [SerializeField] private float _jumpHeight;
        [Header("Move settings")]
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _speed;

        private IInputService _inputService;
        private Vector3 _destination;
        private bool _isCanJump = true;
        private bool _isEnableJump;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _jumpActivator.JumpEnabled += OnEnableJump;
        }

        private void Update()
        {
            //Vector3 input = _inputService.GetDirection();
            Vector3 input = Vector3.zero;

            if (input.magnitude < 0.1f)
            {
                _destination = Vector3.zero;
                _navMeshAgent.velocity = _destination;
                return;
            }

            _destination = _speed * input.normalized;
            
            Move();
            
            if (_isEnableJump)
                Jump();
        }

        private void Jump()
        {
            if (!_isCanJump)
                return;

            _isCanJump = false;
            
            float jumpTime = 0;
            float progress = 0;
            
            StartCoroutine(UseJump());
            IEnumerator UseJump()
            {
                _audioManager.PlayAudioClip();
                while (progress < 1)
                {
                    jumpTime += Time.deltaTime;
                    progress = jumpTime / _jumpDuration;

                    Vector3 position = transform.position;
                    position = new Vector3(position.x, _jumpCurve.Evaluate(progress) * _jumpHeight, position.z);
                    transform.position = position;

                    yield return null;
                }
                
                _isCanJump = true;
            }
        }

        private void OnEnableJump(bool isEnable) => 
            _isEnableJump = isEnable;

        private void Move() =>
            _navMeshAgent.velocity = _destination;

        private void OnDestroy()
        {
            _jumpActivator.JumpEnabled -= OnEnableJump;
        }
    }
}
