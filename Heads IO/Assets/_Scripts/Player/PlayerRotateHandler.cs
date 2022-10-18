using System;
using _Scripts.Services.Input;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerRotateHandler : MonoBehaviour
    {
        [SerializeField] private Transform _model;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _rotationSpeedMultiplier = 3f;
        
        private IInputService _inputService;

        private bool _isBounce;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            Vector3 input = _inputService.GetDirection();
                
            if (input.magnitude < 0.1f)
            {
                if (!_isBounce)
                    StopRotateAnimation();
                
                return;
            }
            
            _model.Rotate(7, 0,0);
            _isBounce = false;
            RotateToTarget(_rotateSpeed * input.normalized);
        }

        private void StopRotateAnimation()
        {
            _isBounce = true;
            
            Vector3 targetRotation = new Vector3(_model.eulerAngles.x - 80, 0, 0);
            
            _model.DOLocalRotate(targetRotation, 0.5f).SetEase(Ease.OutBounce);
        }

        private void RotateToTarget(Vector3 destination)
        {
            Quaternion lookRotation = Quaternion.LookRotation(destination);
            Quaternion myRotation = transform.rotation;

            float speedMultiplier = Mathf.Abs(Quaternion.Angle(myRotation, lookRotation));
            float rotationSpeed = 3 * _rotationSpeedMultiplier * speedMultiplier;

            transform.rotation = Quaternion.Slerp(myRotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        private void OnDestroy()
        {
            _model.DOKill();
            transform.DOKill();
        }
    }
}
