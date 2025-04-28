using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

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

        Transform randomPoint = GetRandomSpawnPoint();

        Enemy enemy = Instantiate(_enemyPrefab, randomPoint.transform.position, Quaternion.identity);
        enemy.Initialize(randomPoint.forward);
    }

    private Transform GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
