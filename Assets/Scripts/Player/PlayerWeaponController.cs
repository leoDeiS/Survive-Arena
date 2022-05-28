using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UUtils;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private Weapon _currentWeapon;

    public UnityEvent<Weapon> OnWeaponSwitched;

    private void Start()
    {
        OnWeaponSwitched?.Invoke(_currentWeapon);
        _currentWeapon.Equip();
    }

    public void Shoot(Vector3 dir)
    {
        _currentWeapon.Shoot(dir);
    }

    public void Reload()
    {
        _currentWeapon.Reload();
    }

    private void SwitchWeapon(Weapon nextWeapon)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = nextWeapon;
        _currentWeapon.gameObject.SetActive(true);
        OnWeaponSwitched?.Invoke(nextWeapon);
    }
}
