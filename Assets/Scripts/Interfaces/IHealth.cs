using UnityEngine;

public interface IHealth
{
    void TakeDamage(float damage);
    void TakeDamage(float damage, Vector3 direction);
    void AddHealth(float amount);
}
