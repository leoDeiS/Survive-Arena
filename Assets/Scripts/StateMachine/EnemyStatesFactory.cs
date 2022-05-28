using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatesFactory
{
    public readonly EnemyIdleState Idle;
    public readonly EnemyChasingState Chasing;
    public readonly EnemyAttackState Attack;

    public EnemyStatesFactory(Enemy enemy)
    {
        Idle = new EnemyIdleState(enemy, this);
        Chasing = new EnemyChasingState(enemy, this);
        Attack = new EnemyAttackState(enemy, this);
    }
}
