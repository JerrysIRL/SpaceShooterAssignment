using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = Unity.Mathematics.Random;

namespace Script.DOTS
{
    public class DataHolderAuthoring : MonoBehaviour
    {
        [Header("Prefabs")] 
        public GameObject enemyPrefab;
        public GameObject bulletPrefab;

        [Header("Enemy properties")] 
        public float enemySpeed;
        public int enemyDamage;

        [Header("Bullet Properties")] 
        public float bulletSpeed;

        [Header("EnemySpawner")] 
        public float enemySpawnRate;
        public int numberToSpawn = 10;
        public float spawnRadius = 15;
        
        [Header("Other")] public uint randomSeed;
        public Transform playerTransform;
        
    }

    public class DataBaker : Baker<DataHolderAuthoring>
    {
        public override void Bake(DataHolderAuthoring authoring)
        {
            var dataEntity = GetEntity(TransformUsageFlags.None);
            AddComponent(dataEntity, new DataProperties()
                {
                    EnemyPrefab = GetEntity(authoring.enemyPrefab, TransformUsageFlags.Dynamic),
                    BulletPrefab = GetEntity(authoring.bulletPrefab, TransformUsageFlags.Dynamic),
                    EnemySpeed = authoring.enemySpeed,
                    EnemyDamage = authoring.enemyDamage,
                    BulletSpeed = authoring.bulletSpeed,
                    SpawnRate = authoring.enemySpawnRate,
                    NumberToSpawn = authoring.numberToSpawn,
                    SpawnRadius = authoring.spawnRadius,
                });
            AddComponent(dataEntity, new DataRandom()
            {   
                Value = Random.CreateFromIndex(authoring.randomSeed)
            });
            AddComponent(dataEntity, new EnemySpawnTimer());
        }
    }
}