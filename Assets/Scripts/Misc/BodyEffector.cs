using UnityEngine;

public class BodyEffector : MonoBehaviour
{
    [SerializeField] bool useForwardVector;
    [SerializeField] Vector3 direction;
    [SerializeField] float force;
    [SerializeField] AudioFX audioFX;
    [SerializeField] AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        var rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            if (!useForwardVector)
                rb.AddForce(force * direction.normalized, ForceMode.Impulse);
            else
                rb.AddForce(force * transform.forward, ForceMode.Impulse);
            
            if (audioFX != null)
                audioFX.PlayFX(source);
        }
    }
}