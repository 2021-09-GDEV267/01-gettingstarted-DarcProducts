using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotateVector;

    void FixedUpdate() => transform.rotation *= Quaternion.Euler(rotateVector);
}