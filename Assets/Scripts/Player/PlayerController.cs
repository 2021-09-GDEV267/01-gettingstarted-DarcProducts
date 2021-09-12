using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float force = 0;
    [SerializeField] float maxVelocity;
    [SerializeField] Transform cameraRotator;

    Rigidbody rb;

    [SerializeField] GlobalVector2Variable movementH;

    void Start() => rb = GetComponent<Rigidbody>();

    public void OnMove(InputValue movementValue) => movementH.Value = movementValue.Get<Vector2>();

    void FixedUpdate()
    {
        float move = movementH.Value.y;
        float currentSpeed = rb.velocity.magnitude;
        Vector3 dir = cameraRotator.transform.forward;
        if (currentSpeed < maxVelocity)
            rb.AddForce(force * move * dir, ForceMode.Force);
    }

    public float Force
    {
        get { return force; }
        set { force = value; }
    }

    public float MaxVelocity
    {
        get { return maxVelocity; }
        set { maxVelocity = value; }
    }

    void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
            collectable.Collect();
    }
}