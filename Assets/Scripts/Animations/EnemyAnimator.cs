using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(RagdollController), typeof(EnemyAnimationEvents))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    private EnemyAnimationEvents _events;
    private RagdollController _ragdoll;

    private int _currentState;

    public EnemyAnimationEvents Events { get => _events; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _events = GetComponent<EnemyAnimationEvents>();
        _ragdoll = GetComponent<RagdollController>();
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

    public void SetAttack()
    {
        _animator.SetTrigger(AnimationStates.Attack);
    }

    public void ResetAttack()
    {
        _animator.ResetTrigger(AnimationStates.Attack);
    }

    public void SetVelocity(float velocity)
    {
        _animator.SetFloat(AnimationStates.Velocity, velocity);
    }

    public void DeathBounce(Vector3 direction)
    {
        _ragdoll.BounceHip(direction, 100f);
    }

    public void SetDeath()
    {
        _animator.enabled = false;
        _ragdoll.Activate();
    }
}
