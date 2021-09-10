using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float force = 0;
    [SerializeField] float maxSpeed;

    Rigidbody rb;

    [SerializeField] GlobalVector2Variable movement;

    void Start() => rb = GetComponent<Rigidbody>();

    void OnMove(InputValue movementValue) => movement.Value = movementValue.Get<Vector2>();

    void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.Value.x, 0.0f, movement.Value.y);
        float currentSpeed = rb.velocity.magnitude;
        if (currentSpeed < maxSpeed)
            rb.AddForce(move * force);
    }

    public float Speed
    {
        get { return force; }
        set { force = value; }
    }
}