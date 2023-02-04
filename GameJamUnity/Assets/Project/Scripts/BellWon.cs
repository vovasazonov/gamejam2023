using System;
using Project.Scripts.Movement;
using UnityEngine;

namespace Project.Scripts
{
    public class BellWon : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerTypeComponent>(out var playerTypeComponent))
            {
                var playerWon = playerTypeComponent.Player;
                PlayersAnimationInvoker.PlayWon(playerWon);

                if (playerWon == PlayerType.One)
                {
                    PlayersAnimationInvoker.PlayLose(PlayerType.Two);
                }
                else
                {
                    PlayersAnimationInvoker.PlayLose(PlayerType.One);
                }
                
                GameManager.Instance.DoEndGameSequance(playerWon, playerWon == PlayerType.One ? PlayerType.Two : PlayerType.One);
            }
        }
    }
}