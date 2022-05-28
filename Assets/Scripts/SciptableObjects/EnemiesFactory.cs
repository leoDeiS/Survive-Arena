using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UUtils;

[CreateAssetMenu(fileName = "EnemiesFactory", menuName = "Data/Enemy/EnemiesFactory", order = 1)]
public class EnemiesFactory : ScriptableObject
{

    [SerializeField] private EnemyStack[] _enemyStacks;

    public EnemyStack[] EnemyStacks { get => _enemyStacks; }
}

[Serializable]
public struct EnemyStack
{
    public Enemy prefab;
    public int count;
}
