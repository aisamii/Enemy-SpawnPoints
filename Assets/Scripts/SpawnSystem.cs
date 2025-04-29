using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private WaitForSeconds _waitForSpawnInterval;

    private void Start()
    {
        _waitForSpawnInterval = new WaitForSeconds(_spawnInterval);

        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return _waitForSpawnInterval;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (_spawnPoints.Count == 0)
            return;

        SpawnPoint randomPoint = GetRandomSpawnPoint();

        Enemy enemy = Instantiate(randomPoint.EnemyPrefab, randomPoint.transform.position, Quaternion.identity);
        enemy.Initialize(randomPoint.EnemyTarget);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
