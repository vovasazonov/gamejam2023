using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    private int _currentCameraMode = 2;

    [SerializeField] private Transform _target;

    // void Update()
    // {
    //     if (_currentCameraMode == 1)
    //     {
    //         transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
    //     }
    // }

    public void ChangeCameraModeToSecondPhase()
    {
        _currentCameraMode = 2;
        var transform1 = transform;
        transform1.position = new Vector3(_target.transform.position.x, _target.transform.position.y + 2,
            _target.position.z - 3);
        transform1.rotation = Quaternion.Euler(30, 0, 0);
    }

    public void ChangeCameraModeToFirstPhase()
    {
        _currentCameraMode = 1;
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
    }
}