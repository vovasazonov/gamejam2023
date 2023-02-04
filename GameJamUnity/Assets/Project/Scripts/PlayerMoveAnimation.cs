using System;
using UnityEngine;

namespace Project.Scripts
{
    public class PlayerMoveAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerTypeComponent _playerType;
        private bool _isMovingAnimation;

        private void Update()
        {
            var isMovingAndNotJumping = (PlayerInputService.IsLeftPressing(_playerType.Player) ||
                                         PlayerInputService.IsRightPressing(_playerType.Player) ||
                                         PlayerInputService.IsDownPressing(_playerType.Player) ||
                                         PlayerInputService.IsUpPressing(_playerType.Player));
            
            if (isMovingAndNotJumping && !_isMovingAnimation)
            {
                PlayersAnimationInvoker.PlayWalk(_playerType.Player);
                _isMovingAnimation = true;
            }
            else if (!isMovingAndNotJumping)
            {
                PlayersAnimationInvoker.PlayIdle(_playerType.Player);
                _isMovingAnimation = false;
            }
        }
    }
}