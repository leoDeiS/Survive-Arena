using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;

    public void PlayShootEffect()
    {
        _shootEffect.Play();
    }
}
