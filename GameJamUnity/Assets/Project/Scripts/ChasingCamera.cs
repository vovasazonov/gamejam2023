using UnityEngine;

public class ChasingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, -10);
    }
}