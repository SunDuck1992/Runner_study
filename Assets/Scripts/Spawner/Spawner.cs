using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPull
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _pointsOfSpawn;

    private float _pastTime;

    private void Start()
    {
        Initialize(_enemyPrefabs);
    }

    private void Update()
    {
        _pastTime += Time.deltaTime;

        if (_pastTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _pastTime = 0;
                int spawnPointNumber = Random.Range(0, _pointsOfSpawn.Length);

                SetEnemy(enemy, _pointsOfSpawn[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
