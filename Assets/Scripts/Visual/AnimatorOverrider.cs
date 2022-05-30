using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils.Animations;

[RequireComponent(typeof(Animator))]
public class AnimatorOverrider : MonoBehaviour
{
    [SerializeField] private AnimationClip _clip;

    private Animator _animator;
    private AnimatorOverrideController _overrideController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
         _overrideController = AnimationOverrider.SetOverrideController(_animator);
        AnimationOverrider.OverrideAnimation(_overrideController, 0, _clip);
    }
}
