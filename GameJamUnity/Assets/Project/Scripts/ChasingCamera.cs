using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;


    public void ChangeCameraModeToSecondPhase()
    {
        var transform1 = transform;
        transform1.position = new Vector3(_target.transform.position.x, _target.transform.position.y + 2,
            _target.position.z - 3);
        transform1.rotation = Quaternion.Euler(30, 0, 0);
    }

    public void ChangeCameraModeToFirstPhase()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y,
            _target.transform.position.y - 10);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}