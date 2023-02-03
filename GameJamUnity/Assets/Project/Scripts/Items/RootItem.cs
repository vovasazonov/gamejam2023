using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts.Items
{
    public class RootItem : Item
    {
        [FormerlySerializedAs("_startRoot")] public Transform _startRootTransform;
        [FormerlySerializedAs("_endRoot")] public Transform _endRootTransform;
        private Transform _followStartTransform;
        private Transform _followEndTransform;

        protected override void OnAction(PlayerType playerType)
        {
        }

        public void SetFollowStartRoot(Transform transform)
        {
            _followStartTransform = transform;
        }

        public void SetFollowEndRoot(Transform transform)
        {
            _followEndTransform = transform;
        }

        private void FixedUpdate()
        {
            _startRootTransform.position = _followStartTransform.position;
            _endRootTransform.position = _followEndTransform.position;
        }
    }
}