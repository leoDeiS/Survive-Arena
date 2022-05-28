using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(RigBuilder))]
public class PlayerIKManager : MonoBehaviour
{
    [SerializeField] private Transform _rightHandGrip;
    [SerializeField] private Transform _leftHandGrip;

    [SerializeField] private Rig _rig;

    private RigBuilder _rigBuilder;

    private void Awake()
    {
        _rigBuilder = GetComponent<RigBuilder>();
    }

    public void Disable()
    {
        _rig.weight = 0;
    }
}
