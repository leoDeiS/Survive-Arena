using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private int _currentState;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _animator = GetComponent<Animator>();
        _currentState = AnimationStates.Idle;
    }

    private void SetBoolState(int nextState)
    {
        _animator.SetBool(_currentState, false);
        _currentState = nextState;
        _animator.SetBool(_currentState, true);
    }

    public void SetIdle()
    {
        SetBoolState(AnimationStates.Idle);
    }

    public void SetVelocity(Vector3 velocity)
    {
        _animator.SetFloat(AnimationStates.Horizontal, velocity.x);
        _animator.SetFloat(AnimationStates.Vertical, velocity.z);
    }
}
