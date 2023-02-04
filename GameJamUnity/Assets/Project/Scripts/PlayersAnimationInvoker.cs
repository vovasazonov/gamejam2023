using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class PlayersAnimationInvoker : MonoBehaviour
    {
        public PlayerType PlayerType;
        public Animator Animator;

        private static Dictionary<PlayerType, PlayersAnimationInvoker> _instances = new();
        private static bool _isAnimateable = true;

        private void Awake()
        {
            _instances.Add(PlayerType, this);
        }

        public static void PlayWalk(PlayerType playerType)
        {
            if (_isAnimateable)
            {
                _instances[playerType].Animator.Play("Walk");
            }
        }

        public static void PlayJump(PlayerType playerType)
        {
            if (_isAnimateable)
            {
                _instances[playerType].Animator.Play("Jump");
            }
        }

        public static void PlayTake(PlayerType playerType)
        {
            if (_isAnimateable)
            {
                _instances[playerType].Animator.Play("Take");
            }
        }

        public static void PlayIdle(PlayerType playerType)
        {
            if (_isAnimateable)
            {
                _instances[playerType].Animator.Play("Idle");
            }
        }

        public static void PlayWon(PlayerType playerType)
        {
            _isAnimateable = false;
            _instances[playerType].Animator.Play("Win");
        }

        public static void PlayLose(PlayerType playerType)
        {
            _isAnimateable = false;
            _instances[playerType].Animator.Play("Lose");
        }
    }
}