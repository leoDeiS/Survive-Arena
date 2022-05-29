using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UUtils;

public class Rifle : Weapon
{

    public UnityEvent OnShoot;

    public override void Reload()
    {
        StartCoroutine(Reloading());
    }

    public override void Shoot(Vector3 direction)
    {
        if(_currentAmmo > 0 && Time.time >= _nextShotTime && !_reloading)
        {
            _nextShotTime = Time.time + 1f / _weaponData.FireRate;
            Bullet bullet = Instantiate(_weaponData.Bullet, _shootPoint.position, _shootPoint.rotation);
            bullet.SetStats(_weaponData.BulletSpeed, _weaponData.Damage);
            bullet.Release(direction);
            SetAmmo(_currentAmmo - 1);
            OnShoot?.Invoke();
        }
    }
}
