using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;

[RequireComponent(typeof(RigBuilder))]
public class PlayerIKManager : MonoBehaviour
{
    [SerializeField] private Transform _reloadPoint;

    [SerializeField] private Transform _rightHandGrip;
    [SerializeField] private Transform _leftHandGrip;

    [SerializeField] private Rig _rig;

    private RigBuilder _rigBuilder;

    private void Awake()
    {
        _rigBuilder = GetComponent<RigBuilder>();
    }

    public void SetNewGrips(Weapon weapon)
    {
        _rightHandGrip = weapon.RightHandGrip;
        _leftHandGrip = weapon.LeftHandGrip;
    }

    public void ReloadIK(float duration)
    {
        Vector3 startPoint = _leftHandGrip.localPosition;
        _leftHandGrip.DOKill();
        _leftHandGrip.DOMove(_reloadPoint.position, duration / 2).SetEase(Ease.InOutSine).
            OnComplete(() => { 
                _leftHandGrip.DOLocalMove(startPoint, duration / 2).SetEase(Ease.InOutSine);
            });
    }

    public void Disable()
    {
        _rig.weight = 0;
    }
}
