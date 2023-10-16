using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab; 
    [SerializeField] private float spawnInterval = 2.0f; // Time between spawns.
    [SerializeField] private float spawnRadius = 5.0f; 
    [SerializeField] private int enemieNumber = 5; // enemies per spawn
    private float _timeSinceLastSpawn = 0;

    private void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemyWave();
            _timeSinceLastSpawn = 0;
        }
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < enemieNumber; i++)
        {
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x, randomPosition.y, 0);
            Instantiate(enemyPrefab, transform.position + spawnPosition, Quaternion.identity);
        }
    }
}