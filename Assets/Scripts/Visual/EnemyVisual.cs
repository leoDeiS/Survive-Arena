using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private GameObject _bloodEffect;
    
    public void CreateBloodEffect()
    {
        Instantiate(_bloodEffect, transform.position + Vector3.up, Quaternion.identity);
    }
}
