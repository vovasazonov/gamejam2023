using System.Collections.Generic;
using Project.Scripts.Movement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<ChasingCamera> _chasingCameras;

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

    private void SetActivePhase1()
    {
        PlayerMovement.SetActiveUnderGround(true);
        // PlayerMovement.SetActiveUpperGround(false);
        foreach (var element in _chasingCameras)
        {
            element.ChangeCameraModeToFirstPhase();
        }
    }

    private void SetActivePhase2()
    {
        PlayerMovement.SetActiveUnderGround(false);
        // PlayerMovement.SetActiveUpperGround(true);
        foreach (var element in _chasingCameras)
        {
            element.ChangeCameraModeToSecondPhase();
        }
    }
}