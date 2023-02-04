using System;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Ui
{
    public class ScoreUpdater : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private PlayerType _player;
        private string _format = $"P{0}: {1}";

        private void Awake()
        {
            int playerNumber = _player == PlayerType.One ? 1 : 2;
            _text.text = $"P{playerNumber}: {PointsCounter.Instance.GetPoints(_player)}";

            PointsCounter.Instance.Updated += OnUpdated;
        }

        private void OnUpdated()
        {
            int playerNumber = _player == PlayerType.One ? 1 : 2;
            _text.text = $"P{playerNumber}: {PointsCounter.Instance.GetPoints(_player)}";
        }
    }
}