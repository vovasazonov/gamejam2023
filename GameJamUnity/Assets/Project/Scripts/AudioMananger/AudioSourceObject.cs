using UnityEngine;

namespace Project.Scripts.AudioMananger
{
    public class AudioSourceObject : MonoBehaviour
    {
        private bool _isStartedPlaying;
        [SerializeField] private AudioSource _audioSourceComponent;

        public void PlaySound(AudioClip audioClip)
        {
            _audioSourceComponent.clip = audioClip;
            _audioSourceComponent.Play();
            _isStartedPlaying = true;
        }

        private void Update()
        {
            if (_isStartedPlaying)
            {
                if (!_audioSourceComponent.isPlaying)
                {
                    Destroy(this);
                }
            }
        }
    }
}