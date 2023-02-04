using Project.Scripts.Movement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Sound.FirstPhaseBackgroundMusic);
        Timer.Instance.StartTimer();
        SetActivePhase1();
        Timer.Instance.TimeOver += OnTimeOver;
    }

    private void OnTimeOver()
    {
        SetActivePhase2();
    }

    private static void SetActivePhase1()
    {
        PlayerMovement.SetActiveUnderGround(true);
        // PlayerMovement.SetActiveUpperGround(false);
        ChasingCamera.Instance.ChangeCameraModeToFirstPhase();
    }
    
    private static void SetActivePhase2()
    {
        PlayerMovement.SetActiveUnderGround(false);
        // PlayerMovement.SetActiveUpperGround(true);
        ChasingCamera.Instance.ChangeCameraModeToSecondPhase();
    }
}