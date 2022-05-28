using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action OnDeath;
    public event Action<float, float> OnHealthChanged;

    private void Awake()
    {
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
            _currentHealth = 0;
            OnDeath?.Invoke();
        }
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage, Vector3 direction)
    {
        TakeDamage(damage);
    }
}
