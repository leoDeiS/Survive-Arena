using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UUtils;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private EnemiesFactory[] _factories;
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private float _spawnDelay;

    private IEnumerator _spawningCoroutine;

    private List<EnemyStack> _enemyStacks;
    private List<Transform> _usedSpawnPoints = new List<Transform>();

    public event Action<Enemy> OnEnemySpawned;
    public event Action OnAllEnemiesSpawned;

    private IEnumerator Spawning()
    {
        while(true)
        {
            Enemy prefab;
            if(!TryGetEnemyPrefab(out prefab))
            {
                OnAllEnemiesSpawned?.Invoke();
                yield break;
            }
            Transform point = GetSpawnPoint();
            Enemy enemy  = Instantiate(prefab, point.position, Quaternion.identity, transform);
            OnEnemySpawned?.Invoke(enemy);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private bool TryGetEnemyPrefab(out Enemy enemy)
    {
        if(_enemyStacks.Count == 0)
        {
            enemy = null;
            return false;
        }
        EnemyStack stack = MathUtils.RandomElement(_enemyStacks);
        stack.count--;
        enemy = stack.prefab;
        if(stack.count == 0)
        {
            _enemyStacks.Remove(stack);
        }
        return true;
    }

    private Transform GetSpawnPoint()
    {
        if(_spawnPoints.Count == 0)
        {
            _spawnPoints = new List<Transform>(_usedSpawnPoints);
            _usedSpawnPoints.Clear();
        }

        Transform spawnPoint = MathUtils.RandomElement(_spawnPoints);
        _usedSpawnPoints.Add(spawnPoint);
        _spawnPoints.Remove(spawnPoint);
        return spawnPoint;
    }

    public void StartSpawn(int wave)
    {
        if(_factories.Length < wave)
        {
            wave = _factories.Length;
        }
        _enemyStacks = _factories[wave - 1].EnemyStacks.ToList();
        this.SetCoroutine(ref _spawningCoroutine, Spawning());
    }

    public void EndSpawn()
    {
        StopCoroutine(_spawningCoroutine);
    }
}
