using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _wavesDelay;

    private EnemiesSpawner _spawner;
    private List<Enemy> _spawnedEnemies = new List<Enemy>();

    private int _currentWave = 1;

    private bool _allEnemiesSpawned;

    public UnityEvent<int> OnWaveStarted;

    private void Awake()
    {
        _spawner = GetComponentInChildren<EnemiesSpawner>();
        _spawner.OnEnemySpawned += SendEnemy;
        _spawner.OnAllEnemiesSpawned += OnAllEnemiesSpawned;
    }

    private void Start()
    {
        _spawner.StartSpawn(_currentWave);
    }

    private void SendEnemy(Enemy enemy)
    {
        enemy.SetTarget(_target);
        enemy.Chase();
        enemy.OnDeath += CheckWave;
    }

    private void CheckWave(Enemy enemy)
    {
        _spawnedEnemies.Remove(enemy);
        if(_allEnemiesSpawned && _spawnedEnemies.Count == 0)
        {
            StartCoroutine(StartNewWave());
        }
    }

    private IEnumerator StartNewWave()
    {
        _currentWave++;
        yield return new WaitForSeconds(_wavesDelay);
        _spawner.UpdateDelay();
        _spawner.StartSpawn(_currentWave);
        OnWaveStarted?.Invoke(_currentWave);
    }

    private void OnAllEnemiesSpawned()
    {
        _allEnemiesSpawned = true;
    }
}
