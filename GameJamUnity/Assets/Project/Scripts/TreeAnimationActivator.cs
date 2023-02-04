using System;
using UnityEngine;

namespace Project.Scripts
{
    public class TreeAnimationActivator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Start()
        {
            GameManager.Instance.Phase2Started += OnPhase2Started;
        }

        private void OnPhase2Started()
        {
            _animator.Play("Growth_Animation");
        }
    }
}