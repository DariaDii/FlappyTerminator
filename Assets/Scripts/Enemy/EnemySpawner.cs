using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private float _delay;
    [SerializeField] private BulletPool _bullet;

    public event Action Released;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            SetEnemiesAtAllPoints();
            yield return delay;
        }
    }

    private void SetEnemiesAtAllPoints()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            SpawnEnemy(spawnPoint);
        }
    }

    private void SpawnEnemy(Transform spawnPoint)
    {
        Enemy enemy = _enemyPool.GetObject();
        enemy.EnemyAttack.Init(_bullet);
        enemy.Destruction += Release;
        enemy.transform.position = spawnPoint.position;
    }

    private void Release(Enemy enemy)
    {
        Released?.Invoke();
        _enemyPool.ReturnToPool(enemy);
        enemy.Destruction -= Release;
    }
}