using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Movement
{
    public abstract class PlayerMovement : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        
        private static readonly Dictionary<PlayerType, MonoBehaviour> Players = new();
        protected PlayerType _playerType;
        private bool _isActive;

        private void Awake()
        {
            _playerType = GetComponent<PlayerTypeComponent>().Player;
            Players[_playerType] = this;
        }

        public static void SetActiveUpperGround(bool isActive)
        {
            foreach (var playerType in Players.Keys)
            {
                var movements = Players[playerType].GetComponents<PlayerMovement>();

                foreach (var movement in movements)
                {
                    if (movement is UpperGroundPlayerMovement)
                    {
                        movement._isActive = isActive;
                        movement.OnActivated();
                    }
                }
            }
        }
        
        public static void SetActiveUnderGround(bool isActive)
        {
            foreach (var playerType in Players.Keys)
            {
                var movements = Players[playerType].GetComponents<PlayerMovement>();

                foreach (var movement in movements)
                {
                    if (movement is UnderGroundPlayerMovement)
                    {
                        movement._isActive = isActive;
                        movement.OnActivated();
                    }
                }
            }
        }

        private void Update()
        {
            if (_isActive)
            {
                Move();
            }
        }

        protected abstract void Move();

        protected abstract void OnActivated();
    }
}