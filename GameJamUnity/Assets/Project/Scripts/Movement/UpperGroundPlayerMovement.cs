using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Project.Scripts.Movement
{
    public class UpperGroundPlayerMovement : PlayerMovement
    {
        // private float howFarCharCanBeFromTree = 10;
        // private float howCloseCharCanBeToTree = 0.5f;

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

// undone code(borders for movement forword and back
            // if (depth != 0)
            // {
            //     if (((Vector3.Distance(_center.position, transform.position) < howFarCharCanBeFromTree) & depth > 0) |
            //         ((Vector3.Distance(_center.position, transform.position) > howCloseCharCanBeToTree) & depth < 0)) ;
            //     {
            //     }
            //
            //     transform.position =
            //         Vector3.MoveTowards(transform.position, _center.position, _speed * Time.deltaTime * depth);
            // }

            transform.RotateAround(_center.position, Vector3.up, -horizontal);
        }

        protected override void OnActivated()
        {
            _camera.ChangeCameraModeToSecondPhase();
            transform.position = _startPosition.position;
        }

   
    }
}