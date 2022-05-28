using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(Enemy stateMachine, EnemyStatesFactory statesFactory)
    : base(stateMachine, statesFactory) { }

    public override void EnterState()
    {
        base.EnterState();
        _stateMachine.Agent.isStopped = true;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _stateMachine.Animator.SetVelocity(_stateMachine.Agent.velocity.magnitude);
    }
}
