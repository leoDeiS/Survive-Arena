using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private EnemiesSpawner _spawner;

    private bool _allEnemiesSpawned;

    private void Awake()
    {
        _spawner = GetComponentInChildren<EnemiesSpawner>();
        _spawner.OnEnemySpawned += SendEnemy;
        _spawner.OnAllEnemiesSpawned += OnAllEnemiesSpawned;
    }

    private void Start()
    {
        _spawner.StartSpawn(1);
    }

    private void SendEnemy(Enemy enemy)
    {
        enemy.SetTarget(_target);
        enemy.Chase();
    }

    private void OnAllEnemiesSpawned()
    {
        _allEnemiesSpawned = true;
    }
}
