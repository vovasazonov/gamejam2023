using System;
using Project.Scripts;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private PlayerType _inAreaPlayer;
    private bool _isInAreaPlayer;

    private void OnCollisionEnter(Collision other)
    {
        if (!_isInAreaPlayer && other.gameObject.TryGetComponent(out PlayerTypeComponent playerType))
        {
            Debug.Log("enter");
            _inAreaPlayer = playerType.Player;
            _isInAreaPlayer = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (_isInAreaPlayer && other.gameObject.TryGetComponent(out PlayerTypeComponent playerType) && playerType == _isInAreaPlayer)
        {
            Debug.Log("exist");
            _isInAreaPlayer = false;
        }
    }

    protected abstract void OnAction(PlayerType playerType);

    private void Update()
    {
        if (_isInAreaPlayer && PlayerInputService.IsActionClicked(_inAreaPlayer))
        {
            OnAction(_inAreaPlayer);
            PlayersAnimationInvoker.PlayTake(_inAreaPlayer);
        }
    }
}
