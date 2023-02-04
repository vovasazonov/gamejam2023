using System;
using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    private int _currentCameraMode = 1;

    [SerializeField] private Transform _target;

    public static ChasingCamera Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (_currentCameraMode == 1)
        {
            transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
        }

        if (_currentCameraMode == 2)
        {
            var transform1 = transform;
            transform1.position = new Vector3(_target.transform.position.x, _target.transform.position.y + 2, -3);
            transform1.rotation = Quaternion.Euler(30, 0, 0);
        }
    }

    public void ChangeCameraModeToFirstPhase()
    {
        _currentCameraMode = 1;
    }

    public void ChangeCameraModeToSecondPhase()
    {
        _currentCameraMode = 2;
    }
}