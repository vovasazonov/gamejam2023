using System;
using System.Collections.Generic;
using Project.Scripts.AudioMananger;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _audioManager;
    private static List<AudioSourceObject> _soundChoosedNow = new List<AudioSourceObject>();
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
        FirstPhaseBackgroundMusic,
        SecondPhaseBackgroundMusic
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

        var audioSourceObject = Instantiate(_audioSourcePrefab);
        audioSourceObject.PlaySound(audioClip);
        _soundChoosedNow.Add(audioSourceObject);
    }

    public static void StopAllAudio()
    {
        if (_soundChoosedNow != null)
        {
            foreach (var element in _soundChoosedNow)
            {
                element.StopSound();
            }
        }
    }
}