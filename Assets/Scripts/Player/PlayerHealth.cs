using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    public UnityAction OnPlayerDied;

    [Header("Value Changes Dynamically")]
    [SerializeField] float currentHealth;

    [Space(16)]
    [SerializeField] float maxHealth;
    [Space(16)]
    [SerializeField] ObjectPooler damageEffectPool;

    void Start() => currentHealth = maxHealth;

    public void ApplyDamage(float dmg)
    {
        currentHealth -= dmg;

        if (damageEffectPool != null)
        {
            GameObject effect = damageEffectPool.GetObject();
            effect.transform.SetPositionAndRotation(transform.position, Quaternion.identity);
            effect.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            OnPlayerDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}