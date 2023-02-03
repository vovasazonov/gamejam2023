using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Items
{
    public class BottomTreeItem : Item
    {
        [SerializeField] private RootItem _rootItemPrefab;
        [FormerlySerializedAs("_playerType")] [SerializeField] private PlayerTypeComponent _playerThatRelatedTo;
        
        protected override void OnAction(PlayerType playerType)
        {
            var rootItem = Instantiate(_rootItemPrefab);
            rootItem.SetFollowStartRoot(transform);
            rootItem.SetFollowEndRoot(_playerThatRelatedTo.transform);
        }
    }
}