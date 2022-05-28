using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private Transform _root;

    private Rigidbody[] _boides;
    private Collider[] _colliders;

    private void Awake()
    {
        _boides = _root.GetComponentsInChildren<Rigidbody>();
        _colliders = _root.GetComponentsInChildren<Collider>();
        Deactivate();
    }

    public void BounceHip(Vector3 direction, float force)
    {
        MathUtils.RandomElement(_boides).AddForce(direction * force, ForceMode.Impulse);
    }

    public void Activate()
    {
        for (int i = 0; i < _boides.Length; i++)
        {
            _boides[i].isKinematic = false;
            _colliders[i].enabled = true;
        }
    }

    public void Deactivate()
    {
        for (int i = 0; i < _boides.Length; i++)
        {
            _colliders[i].enabled = false;
            _boides[i].isKinematic = true;
        }
    }
}
