using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UUtils;

public class WeaponUI : BaseUIBehaviour
{
    [SerializeField] private PlayerWeaponController _weaponController;
    [SerializeField] private ReloadingIcon _reloadingIcon;
    [SerializeField] private TextMeshProUGUI _ammoText;
    [SerializeField] private Transform _crosshair;

    private string _ammoTextFormat = "{0}/{1}";


    protected override void Awake()
    {
        base.Awake();
        _weaponController.OnWeaponSwitched.AddListener(OnWeaponSwitched);
    }

    private void OnWeaponSwitched(Weapon weapon)
    {
        weapon.OnAmmoValueChanged.AddListener(SetAmmoText);
        weapon.OnReloadingStarted.AddListener( OnReloadingStarted);
        weapon.OnReloadingComplete.AddListener(OnReloadingCompleted);
    }

    private void SetAmmoText(int current, int max)
    {
        _ammoText.text = string.Format(_ammoTextFormat, current, max);
    }

    private void OnReloadingStarted()
    {
        _reloadingIcon.Show();
    }
    private void OnReloadingCompleted()
    {
        _reloadingIcon.Hide();
    }

    private void Update()
    {
        _crosshair.position = Input.mousePosition;
    }

}
