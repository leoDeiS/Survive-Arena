using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData _weaponData;
    [SerializeField] protected Transform _shootPoint;

    protected Camera _camera;

    protected float _reloadTime;
    protected float _nextShotTime;

    protected bool _reloading;

    protected int _currentAmmo { get; private set; }

    public UnityEvent OnReloadingStarted;
    public UnityEvent OnReloadingComplete;
    public UnityEvent<int, int> OnAmmoValueChanged;

    protected virtual void Awake()
    {
        SetAmmo(_weaponData.MaxAmmo);
    }

    protected IEnumerator Reloading()
    {
        if (_reloading) yield break;

        OnReloadingStarted?.Invoke();
        while(Time.time <= _reloadTime)
        {
            _reloadTime = Time.time + 1f / _weaponData.FireRate;
        }
        SetAmmo(_weaponData.MaxAmmo);
        OnReloadingComplete?.Invoke();
    }

    protected void SetAmmo(int count)
    {
        _currentAmmo = count;
        OnAmmoValueChanged?.Invoke(count, _weaponData.MaxAmmo);
    }

    public abstract void Shoot(Vector3 point);
    public abstract void Reload();


    public virtual void Equip()
    {
        gameObject.SetActive(true);
    }

    public virtual void Uneqiup()
    {
        OnAmmoValueChanged?.RemoveAllListeners();
        OnReloadingComplete.RemoveAllListeners();
        OnReloadingStarted.RemoveAllListeners();
        gameObject.SetActive(false);
    }

}
