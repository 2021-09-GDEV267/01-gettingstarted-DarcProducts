using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] float spikeDamage;
    [SerializeField] float hitForce;

    [SerializeField] AudioFX audioFX;
    [SerializeField] AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        var otherRigid = other.GetComponent<Rigidbody>();
        var damage = other.GetComponent<IDamagable>();
        var shrink = other.GetComponent<PlayerScaling>();

        if (otherRigid != null)
            otherRigid.AddForce(Vector3.up * hitForce);
        if (damage != null)
            damage.ApplyDamage(spikeDamage);
        if (shrink != null)
            shrink.ShrinkPlayer();

        if (audioFX != null)
            audioFX.PlayFX(source);
    }
}