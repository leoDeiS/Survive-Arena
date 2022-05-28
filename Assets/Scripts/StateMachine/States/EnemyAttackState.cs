using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

public class EnemyAttackState : EnemyBaseState
{
    private bool _attackStopped;
    private bool _canDamage = true;

    private IEnumerator _rechargingCoroutine;

    public EnemyAttackState(Enemy stateMachine, EnemyStatesFactory statesFactory)
    : base(stateMachine, statesFactory) { }

    private void StartAttack()
    {
        _canDamage = false;
        _attackStopped = false;
        _stateMachine.Animator.SetAttack();
    }

    private void Recharge()
    {
        _stateMachine.SetCoroutine(ref _rechargingCoroutine, Recharging());
    }

    private IEnumerator Recharging()
    {   
       _attackStopped = true;
        yield return new WaitForSeconds(_stateMachine.Data.AttackDelay);
        _canDamage = true;
    }

    private bool Nearby()
    {
        return MathUtils.InRange(
            _stateMachine.transform.position,
            _stateMachine.Target.position,
            _stateMachine.Data.AttackDistance);
    }

    private void DamageTarget()
    {
        if(Nearby())
        {
            _stateMachine.DamageTarget();
        }
    }

    public override void EnterState()
    {
        base.EnterState();
        _stateMachine.Agent.isStopped = true;
        _canDamage = true;
        _stateMachine.Animator.Events.OnAttackStarted.AddListener(DamageTarget);
        _stateMachine.Animator.Events.OnAttackEnded.AddListener(Recharge);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        bool nearby = Nearby();
        if (nearby && _canDamage)
        {
            StartAttack();
        }
        else if(!nearby && _attackStopped)
        {
            _stateMachine.SwitchState(_statesFactory.Chasing);
        }
        _stateMachine.Animator.SetVelocity(0);
    }

    public override void ExitState()
    {
        base.ExitState();
        _stateMachine.Animator.Events.OnAttackStarted.RemoveListener(DamageTarget);
        _stateMachine.Animator.Events.OnAttackEnded.RemoveListener(Recharge);
        if(_rechargingCoroutine != null)
        {
            _stateMachine.StopCoroutine(_rechargingCoroutine);
        }
    }
}
