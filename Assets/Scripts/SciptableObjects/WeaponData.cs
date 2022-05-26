using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Data/Weapon/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private Bullet _bullet;

    public float Damage { get => _damage; }
    public float FireRate { get => _fireRate; }
    public float ReloadSpeed { get => _reloadTime; }
    public float BulletSpeed { get => _bulletSpeed; }
    public int MaxAmmo { get => _maxAmmo; }
    public Bullet Bullet { get => _bullet; }
}
