using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public static event Action OnDamaged;
    public static event Action OnDeath;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        OnDamaged?.Invoke();

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}