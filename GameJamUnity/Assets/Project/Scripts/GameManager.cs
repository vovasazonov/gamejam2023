using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Sound.FirstPhaseBackgroundMusic);
    }
}