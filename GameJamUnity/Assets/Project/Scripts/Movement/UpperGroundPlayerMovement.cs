using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.Movement
{
    public class UpperGroundPlayerMovement : PlayerMovement
    {
        [SerializeField] private float howFarCharCanBeFromTree;
        [SerializeField] private float howCloseCharCanBeToTree;

        private bool _isGrounded;
        [SerializeField] private float _jumpForce;

        [SerializeField] private Transform _center;
        [SerializeField] private Transform _startPosition;
        [SerializeField] private ChasingCamera _camera;
        [SerializeField] private Rigidbody _rigidbody;


        protected override void Move()
        {
            var horizontal =
                PlayerInputService.IsLeftPressing(_playerType) ? -1 :
                PlayerInputService.IsRightPressing(_playerType) ? 1 : 0;

            var depth =
                PlayerInputService.IsDownPressing(_playerType) ? -1 :
                PlayerInputService.IsUpPressing(_playerType) ? 1 : 0;

            var jump = PlayerInputService.IsActionPressing(_playerType);
            if (jump & _isGrounded)
            {
                PlayersAnimationInvoker.PlayJump(_playerType);
                _rigidbody.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            }

            if (depth != 0)
            {
                float distance = Vector3.Distance(_center.position, transform.position);
                if ((distance < howFarCharCanBeFromTree) && (depth < 0))
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, _center.position, _speed * Time.deltaTime * depth);
                }

                if (((distance > howCloseCharCanBeToTree) && (depth > 0)))
                {
                    transform.position =
                        Vector3.MoveTowards(transform.position, _center.position, _speed * Time.deltaTime * depth);
                }
            }

            transform.RotateAround(_center.position, Vector3.up, -horizontal * _speed);

            var lookPosition = new Vector3(_center.position.x, transform.position.y, _center.position.z);
            transform.LookAt(lookPosition);
        }

        protected override void OnActivated()
        {
            _camera.ChangeCameraModeToSecondPhase();
            transform.position = _startPosition.position;
            _rigidbody.useGravity = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            _isGrounded = true;
        }

        private void OnCollisionExit(Collision other)
        {
            _isGrounded = false;
        }
    }
}