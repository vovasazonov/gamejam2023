using System;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action TimeOver;

    private bool _isTimerStarted;
    private float _timePassed;
    [SerializeField] private float _timeShouldPass;

    private static Timer _instance;

    public static Timer Instance => _instance;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        if (_isTimerStarted)
        {
            _timePassed += Time.deltaTime;
            if (_timePassed >= _timeShouldPass)
            {
                _isTimerStarted = false;
                TimeOver?.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        _timePassed = 0;
        _isTimerStarted = true;
    }

    public int ShowHowMuchTimePassed()
    {
        int timeLast = (_timeShouldPass - _timePassed).ConvertTo<int>();
        return timeLast;
    }

    public void SetTime(int seconds)
    {
        _timeShouldPass = seconds;
    }
}