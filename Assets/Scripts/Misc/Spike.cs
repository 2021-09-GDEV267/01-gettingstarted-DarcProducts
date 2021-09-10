using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float spikeDamage;
    [SerializeField] float hitForce;
    [SerializeField] AudioClip hitSound;
    [SerializeField] AudioSource soundSource;

    void OnTriggerEnter(Collider other)
    {
        var otherRigid = other.attachedRigidbody;
        var damage = other.GetComponent<IDamagable>();
        var shrink = other.GetComponent<PlayerScaling>();

        if (otherRigid != null)
            otherRigid.AddForce(Vector3.up * hitForce);
        if (damage != null)
            damage.ApplyDamage(spikeDamage);
        if (shrink != null)
            shrink.ShrinkPlayer();
        if (soundSource != null && hitSound != null)
            soundSource.PlayOneShot(hitSound);
    }
}