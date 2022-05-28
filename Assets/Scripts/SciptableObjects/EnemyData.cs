using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData", order = 2)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _heath;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    public float Speed { get => _speed; }
    public float Heath { get => _heath; }
    public float Damage { get => _damage; }
    public float AttackDelay { get => _attackDelay; }
    public float AttackDistance { get => _attackDistance; }
}
