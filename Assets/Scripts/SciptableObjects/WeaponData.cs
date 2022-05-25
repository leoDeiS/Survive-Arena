using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Data/Weapon/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _maxAmmo;
    [SerializeField] private float _shootDelay;
    [SerializeField] private float _reloadTime;

    public float Damage { get => _damage; }
    public float MaxAmmo { get => _maxAmmo; }
    public float ShootDelay { get => _shootDelay; }
    public float ReloadSpeed { get => _reloadTime; }
}
