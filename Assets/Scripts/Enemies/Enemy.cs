using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UUtils;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData _data;

    private EnemyAnimator _animator;
    private EnemyHealth _health;
    private NavMeshAgent _agent;

    private EnemyStatesFactory _statesFactory;
    private EnemyBaseState _currentState;

    public Transform Target { get; private set; }
    public IHealth TargetHealth { get; private set; }
    public EnemyAnimator Animator { get => _animator; }
    public EnemyHealth Health { get => _health; }
    public NavMeshAgent Agent { get => _agent; }
    public EnemyData Data { get => _data; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<EnemyAnimator>();
        InitializeHealth();
        InitializeStateMachne();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    private void InitializeStateMachne()
    {
        _statesFactory = new EnemyStatesFactory(this);
        _currentState = _statesFactory.Idle;
    }

    private void InitializeHealth()
    {
        _health = GetComponent<EnemyHealth>();
        _health.Initialize(_data.Heath);
        _health.OnDeath += Die;
    }

    public void SwitchState(EnemyBaseState newState)
    {
        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    public void SetTarget(Transform target)
    {
        Target = target;
        TargetHealth = target.GetComponent<IHealth>();
    }

    public void DamageTarget()
    {
        TargetHealth.TakeDamage(_data.Damage);
    }

    public void Chase()
    {
       SwitchState(_statesFactory.Chasing);
    }

    public void Attack()
    {
        SwitchState(_statesFactory.Attack);
    }

    public void Stop()
    {
        SwitchState(_statesFactory.Idle);
    }

    public void Die()
    {
        SwitchState(_statesFactory.Idle);
        _agent.enabled = false;
        _animator.SetDeath();
        _animator.DeathBounce(_health.LastHitDirection);
    }
}
