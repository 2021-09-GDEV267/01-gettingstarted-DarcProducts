using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform rotateTransform;
    [SerializeField] GlobalVector2Variable movement;
    [SerializeField] float rotateSpeed;
    void FixedUpdate()
    {
        if (movement.Value.x.Equals(1))
            rotateTransform.Rotate(Vector3.up * rotateSpeed * movement.Value.x * Time.fixedDeltaTime);
        if (movement.Value.x.Equals(-1))
            rotateTransform.Rotate(Vector3.down * rotateSpeed * -movement.Value.x * Time.fixedDeltaTime);

        var rotPos = targetTransform.position;

        rotateTransform.position = rotPos;
    }
}
