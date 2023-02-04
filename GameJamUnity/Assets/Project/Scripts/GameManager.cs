using System.Collections.Generic;
using Project.Scripts;
using Project.Scripts.Movement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<ChasingCamera> _chasingCameras;

    private void Start()
    {
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
        AudioManager.StopAllAudio();
        AudioManager.Instance.PlayAudio(AudioManager.Sound.FirstPhaseBackgroundMusic);
        PlayerMovement.SetActiveUpperGround(false);
        PlayerMovement.SetActiveUnderGround(true);
        foreach (var element in _chasingCameras)
        {
            element.ChangeCameraModeToFirstPhase();
        }
    }

    private void SetActivePhase2()
    {
        AudioManager.StopAllAudio();

        AudioManager.Instance.PlayAudio(AudioManager.Sound.SecondPhaseBackgroundMusic);
        LeafsGenerator.StartGenerate();
        PlayerMovement.SetActiveUnderGround(false);
        PlayerMovement.SetActiveUpperGround(true);
        foreach (var element in _chasingCameras)
        {
            element.ChangeCameraModeToSecondPhase();
        }
    }
}