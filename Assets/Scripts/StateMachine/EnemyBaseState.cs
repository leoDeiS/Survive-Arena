using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    protected readonly Enemy _stateMachine;
    protected readonly EnemyStatesFactory _statesFactory;

    public EnemyBaseState(Enemy stateMachine, EnemyStatesFactory statesFactory)
    {
        _stateMachine = stateMachine;
        _statesFactory = statesFactory;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }
}
