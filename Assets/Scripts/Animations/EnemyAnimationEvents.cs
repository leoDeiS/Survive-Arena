using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimationEvents : MonoBehaviour
{
    public UnityEvent OnAttackStarted;
    public UnityEvent OnAttackEnded;

    public void StartAttack()
    {
        OnAttackStarted?.Invoke();
    }

    public void EndAttack()
    {
        OnAttackEnded?.Invoke();
    }
}
