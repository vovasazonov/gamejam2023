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

        public void StopSound()
        {
            _audioSourceComponent.Stop();
        }

        private void Update()
        {
            if (_isStartedPlaying)
            {
                _audioSourceComponent.volume = AudioManager.Instance.Volume;

                if (!_audioSourceComponent.isPlaying)
                {
                    Destroy(this);
                }
            }
        }
    }
}