using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Project.Scripts
{
    public class LeafsGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _leafPrefab;
        [SerializeField] private float _maxWidth;
        [SerializeField] private float _minWidth;
        [SerializeField] private float _betweenLeafsHeight;
        [SerializeField] private float _distanceFromTree;
        [SerializeField] private Transform _bottomPoint;
        [SerializeField] private Transform _topPoint;
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private PlayerType _playerOwner;

        private static Dictionary<PlayerType, LeafsGenerator> _instances = new();

        private void Awake()
        {
            _instances.Add(_playerOwner, this);
        }

        public static void StartGenerate()
        {
            foreach (var player in _instances.Keys)
            {
                _instances[player].Generate();
            }
        }

        private void Generate()
        {
            float currentHeight = 0;
            float totalHeight = _topPoint.position.y - _bottomPoint.position.y;
            GameObject lastLeaf = null;

            while (currentHeight < totalHeight)
            {
                currentHeight += _betweenLeafsHeight;
                var spawnHeight = _bottomPoint.position.y + currentHeight;

                var leaf = Instantiate(_leafPrefab);
                leaf.transform.position = new Vector3(_distanceFromTree,spawnHeight,0);
                transform.RotateAround(_centerPoint.position, Vector3.up, 1);
            }
        }
    }
}