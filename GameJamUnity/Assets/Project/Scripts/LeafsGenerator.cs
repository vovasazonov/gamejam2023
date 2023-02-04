using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts
{
    public class LeafsGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _leafPrefab;
        [SerializeField] private float _maxAngel;
        [SerializeField] private float _minAngel;
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
            var hasLastLeaf = false;
            var lastAngle = 0f;
            var randomBorder = 50;
            
            while (currentHeight < totalHeight)
            {
                currentHeight += _betweenLeafsHeight;
                var spawnHeight = _bottomPoint.position.y + currentHeight;
                var isSpawnInLeftSide = Random.Range(0, 100) > randomBorder;

                var leaf = Instantiate(_leafPrefab, this.transform);
                var position = transform.position;
                position.y = spawnHeight;
                position.x += _distanceFromTree;
                float angelRotate = 0;
                if (hasLastLeaf)
                {
                    angelRotate = isSpawnInLeftSide ? lastAngle + _minAngel : lastAngle - _minAngel;
                    randomBorder = isSpawnInLeftSide ? randomBorder + 10 : randomBorder - 10;
                }
                leaf.transform.position = position;
                leaf.transform.RotateAround(_centerPoint.position, Vector3.up, angelRotate);
                hasLastLeaf = true;
                lastAngle = angelRotate;
            }
        }
    }
}