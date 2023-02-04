using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Items
{
    public class BottomTreeItem : Item
    {
        [SerializeField] private RootItem _rootItemPrefab;

        [FormerlySerializedAs("_playerType")] [SerializeField]
        private PlayerTypeComponent _playerThatRelatedTo;

        private bool _isLocked;

        public static Dictionary<PlayerType, BottomTreeItem> Instances = new();
        public bool IsLock => _isLocked;

        private RootItem CurrentRootItem;

        private void Awake()
        {
            Instances.Add(_playerThatRelatedTo.Player, this);
        }

        protected override void OnAction(PlayerType playerType)
        {
            if (_playerThatRelatedTo.Player == playerType && !_isLocked)
            {
                var rootItem = Instantiate(_rootItemPrefab);
                rootItem.SetFollowStartRoot(transform);
                rootItem.SetFollowEndRoot(_playerThatRelatedTo.transform);
                CurrentRootItem = rootItem;
                Lock();
            }
        }

        public void Lock()
        {
            _isLocked = true;
        }
        
        public void Unlock()
        {
            _isLocked = false;
            Destroy(CurrentRootItem.GetComponent<RootItem>());
        }
    }
}