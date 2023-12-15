using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 2.0f; // Time between spawns.
    [SerializeField] private float spawnRadius = 5.0f;
    [SerializeField] private int enemieNumber = 5;
    [SerializeField] private int poolSize = 1000;

    public static EnemySpawner Instance { get; private set; }

    private Queue<GameObject> inactiveEnemies = new Queue<GameObject>();
    private DataHolder _dataHolder;
    private float _timeSinceLastSpawn = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        ExpandPool(poolSize);
    }

    private void Start()
    {
        _dataHolder = DataHolder.Instance;
        SpawnEnemyWave();
    }

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemyWave();
            _timeSinceLastSpawn = 0;
        }
    }


    public GameObject GetPooledEnemy()
    {
        if (inactiveEnemies.Count == 0)
        {
            ExpandPool(1000); // Expand the pool if there are no inactive objects.
        }

        GameObject enemy = inactiveEnemies.Dequeue();
        enemy.SetActive(true);

        return enemy;
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        inactiveEnemies.Enqueue(enemy);
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < enemieNumber; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, 0);
            GetPooledEnemy().transform.position = spawnPosition;
        }

        _dataHolder.enemyCounter += enemieNumber;
    }

    private void ExpandPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            inactiveEnemies.Enqueue(enemy);
        }
    }
}