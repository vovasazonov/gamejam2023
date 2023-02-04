using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.Movement
{
    public class UpperGroundPlayerMovement : PlayerMovement
    {
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
            Vector3.Distance(transform.position, _center.position);

            if (depth != 0)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _center.position, _speed * Time.deltaTime * depth);
            }

            transform.RotateAround(_center.position, Vector3.up, horizontal);
        }

        protected override void OnActivated()
        {
            _camera.ChangeCameraModeToSecondPhase();
            _rigidbody.MovePosition(_startPosition.position);
        }
    }
}