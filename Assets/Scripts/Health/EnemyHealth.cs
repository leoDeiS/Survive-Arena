using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private CapsuleCollider _collider;
    private float _maxHealth;
    private float _currentHealth;

    public Vector3 LastHitDirection { get; private set; }

    public event Action OnDeath;
    public event Action OnDamage;
    public event Action<float, float> OnHealthChanged;

    public void Initialize(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = _maxHealth;
    }

    public void AddHealth(float amount)
    {
        _currentHealth += amount;
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
        OnDamage?.Invoke();
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);
    }

    public void TakeDamage(float damage, Vector3 direction)
    {
        LastHitDirection = direction;
        TakeDamage(damage);
    }

    public void Die()
    {
        _collider.enabled = false;
        _currentHealth = 0;
        OnDeath?.Invoke();
    }
}
