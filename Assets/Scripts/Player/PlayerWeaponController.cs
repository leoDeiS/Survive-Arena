using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Transform _weaponHolder;
    [SerializeField] private Weapon _currentWeapon;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            _currentWeapon.Reload();
        }
    }

    private void Shoot()
    {
        _currentWeapon.Shoot(transform.forward);
    }

    private void SwitchWeapon(Weapon nextWeapon)
    {
        _currentWeapon.gameObject.SetActive(false);
        _currentWeapon = nextWeapon;
        _currentWeapon.gameObject.SetActive(true);
    }
}
