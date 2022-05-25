using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData _weaponData;
    [SerializeField] protected Transform _shootPoint;

    protected Camera _camera;

    protected virtual void Awake()
    {

    }

    public abstract void Shoot(Vector3 point);
    public abstract void Reload();


}
