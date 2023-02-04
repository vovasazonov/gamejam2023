using TMPro;
using UnityEngine;

namespace Project.Scripts.Movement
{
    public class UnderGroundPlayerMovement : PlayerMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ChasingCamera _camera;
        [SerializeField] private Transform _startPosition;


        protected override void Move()
        {
            var horizontal =
                PlayerInputService.IsLeftPressing(_playerType) ? -1 :
                PlayerInputService.IsRightPressing(_playerType) ? 1 : 0;

            var vertical =
                PlayerInputService.IsDownPressing(_playerType) ? -1 :
                PlayerInputService.IsUpPressing(_playerType) ? 1 : 0;


            var input = new Vector3(horizontal, vertical, 0);

            _rigidbody.MovePosition(transform.position +
                                    input.normalized * input.normalized.magnitude * _speed * Time.deltaTime);
        }

        protected override void OnActivated()
        {
            _rigidbody.useGravity = false;
            transform.position = _startPosition.position;
            _camera.ChangeCameraModeToFirstPhase();
        }

        // private void Start()
        // {
        //     SetActiveUpperGround(false);
        //     SetActiveUnderGround(true);
        // }
    }
}