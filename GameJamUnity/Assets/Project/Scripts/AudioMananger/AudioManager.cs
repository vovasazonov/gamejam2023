using System;
using System.Collections.Generic;
using Project.Scripts.AudioMananger;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _audioManager;
    [SerializeField] private AudioSourceObject _audioSourcePrefab;

    public List<SoundByType> Clips;
    public float Volume { get; set; } = 1;

    public static AudioManager Instance => _audioManager;

    private void Awake()
    {
        if (_audioManager == null)
        {
            _audioManager = this;
        }
    }

    [Serializable]
    public struct SoundByType
    {
        public Sound Sound;
        public AudioClip Clip;
    }

    public enum Sound
    {
        FirstPhaseBackgroundMusic
    }

    public void PlayAudio(Sound sound)
    {
        AudioClip audioClip = null;
        foreach (var element in Clips)
        {
            if (element.Sound == sound)
            {
                audioClip = element.Clip;
            }
        }

        var audioSource = Instantiate(_audioSourcePrefab);
        audioSource.PlaySound(audioClip);
    }
}