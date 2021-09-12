using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public static UnityAction OnPlayerDied;

    [Space(16)]
    [SerializeField] float maxHealth;
    [Space(16)]
    [SerializeField] ObjectPooler damageEffectPool;

    float currentHealth;

    void Start() => currentHealth = maxHealth;

    public void ApplyDamage(float dmg)
    {
        currentHealth -= dmg;

        ActivateDamageEffect();

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }

    public void ActivateDamageEffect()
    {
        if (damageEffectPool != null)
        {
            GameObject effect = damageEffectPool.GetObject();
            effect.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            effect.SetActive(true);
        }
    }
}