using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class PlayerInputService : MonoBehaviour
    {
        [SerializeField] private KeyCode _upKey;
        [SerializeField] private KeyCode _downKey;
        [SerializeField] private KeyCode _leftKey;
        [SerializeField] private KeyCode _rightKey;
        [SerializeField] private KeyCode _actionKey;
        
        private static readonly Dictionary<PlayerType, PlayerInputService> _players = new();

        private void Awake()
        {
            var playerType = GetComponent<PlayerTypeComponent>().Player;
            _players.Add(playerType, this);
        }

        public static bool IsActionClicked(PlayerType playerType)
        {
            return Input.GetKeyUp(_players[playerType]._actionKey);
        }
        
        public static bool IsActionPressing(PlayerType playerType)
        {
            return Input.GetKey(_players[playerType]._actionKey);
        }

        public static bool IsUpPressing(PlayerType playerType)
        {
            return Input.GetKey(_players[playerType]._upKey);
        }
        
        public static bool IsDownPressing(PlayerType playerType)
        {
            return Input.GetKey(_players[playerType]._downKey);
        }
        
        public static bool IsLeftPressing(PlayerType playerType)
        {
            return Input.GetKey(_players[playerType]._leftKey);
        }
        
        public static bool IsRightPressing(PlayerType playerType)
        {
            return Input.GetKey(_players[playerType]._rightKey);
        }
    }
}