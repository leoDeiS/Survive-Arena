using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData _weaponData;
    [SerializeField] protected Transform _shootPoint;

    protected Camera _camera;

    protected int _currentAmmo;
    protected float _nextShotTime;

    protected virtual void Awake()
    {
        _currentAmmo = _weaponData.MaxAmmo;
    }

    public abstract void Shoot(Vector3 point);
    public abstract void Reload();


}
