using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerIKManager), typeof(RagdollController))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private float _smoothing;

    private Animator _animator;
    private PlayerIKManager _ikManager;
    private RagdollController _ragdoll;

    private int _currentState;

    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _animator = GetComponent<Animator>();
        _ikManager = GetComponent<PlayerIKManager>();
        _ragdoll = GetComponent<RagdollController>();
        _currentState = AnimationStates.Idle;
    }

    private Vector3 SmoothVelocity(Vector3 vector)
    {
        Vector3 smooth = Vector3.MoveTowards(_velocity, vector, _smoothing * Time.deltaTime);
        return smooth;
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
        _velocity = SmoothVelocity(velocity);
        _animator.SetFloat(AnimationStates.Horizontal, _velocity.x);
        _animator.SetFloat(AnimationStates.Vertical, _velocity.z);
    }

    public void SetReloading(float duration)
    {
        _ikManager.ReloadIK(duration);
    }

    public void SetDeath()
    {
        _animator.enabled = false;
        _ragdoll.Activate();
    }

}
