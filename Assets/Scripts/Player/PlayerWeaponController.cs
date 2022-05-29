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

    private PlayerAnimator _animator;

    public UnityEvent<Weapon> OnWeaponSwitched;

    private void Awake()
    {
        _animator = GetComponentInChildren<PlayerAnimator>();
    }

    private void Start()
    {
        OnWeaponSwitched?.Invoke(_currentWeapon);
        _currentWeapon.Equip();
        _currentWeapon.OnReloadingStarted.AddListener(OnReloading);
    }

    public void Shoot(Vector3 dir)
    {
        _currentWeapon.Shoot(dir);
    }

    public void Reload()
    {
        _currentWeapon.Reload();
    }

    public void OnReloading()
    {
        _animator.SetReloading(_currentWeapon.WeaponData.ReloadSpeed);
    }

    private void SwitchWeapon(Weapon nextWeapon)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon.OnReloadingStarted.RemoveListener(OnReloading);
        _currentWeapon = nextWeapon;
        _currentWeapon.gameObject.SetActive(true);
        _currentWeapon.OnReloadingStarted.AddListener(OnReloading);
        OnWeaponSwitched?.Invoke(nextWeapon);
    }
}
