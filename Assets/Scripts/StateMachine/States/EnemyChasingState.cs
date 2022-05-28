using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

public class EnemyChasingState : EnemyBaseState
{
    public EnemyChasingState(Enemy stateMachine, EnemyStatesFactory statesFactory)
        : base(stateMachine, statesFactory) { }

    public override void EnterState()
    {
        base.EnterState();
        _stateMachine.Agent.isStopped = false;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(MathUtils.InRange(
            _stateMachine.transform.position,
            _stateMachine.Target.position,
            _stateMachine.Data.AttackDistance))
        {
            _stateMachine.Attack();
        }
        else
        {
            _stateMachine.Agent.SetDestination(_stateMachine.Target.position);
        }

        _stateMachine.Animator.SetVelocity(_stateMachine.Agent.velocity.magnitude);
    }

}
