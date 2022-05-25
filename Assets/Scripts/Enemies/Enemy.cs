using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UUtils;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;

    private Transform _target;
    private EnemyAnimator _animator;
    private NavMeshAgent _agent;

    private IEnumerator _chasingCoroutine;

    private IEnumerator Chasing()
    {
        while(true)
        {
            if (MathUtils.InRange(transform.position, _target.position, _attackDistance))
            {
                
            }
            else
            {
                _agent.SetDestination(_target.position);
            }
            yield return null;
        }
    }

    public void Initialize(Transform target)
    {
        _target = target;
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<EnemyAnimator>();
    }

    public void ChaseTarget()
    {
        this.SetCoroutine(ref _chasingCoroutine, Chasing());
    }

    public void Stop()
    {
        StopCoroutine(_chasingCoroutine);
    }
}
