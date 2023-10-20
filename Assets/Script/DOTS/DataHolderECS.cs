using Unity.Entities;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Script.DOTS
{
    public class DataHolderECS : MonoBehaviour
    {
        [Header("Prefabs")] 
        public GameObject enemyPrefab;
        public GameObject bulletPrefab;

        [Header("Enemy properties")] 
        public float enemySpeed;
        public int enemyDamage;

        [Header("Bullet Properties")] 
        public float bulletSpeed;

        [Header("Other")] public uint randomSeed;

    }

    public class DataBaker : Baker<DataHolderECS>
    {
        public override void Bake(DataHolderECS authoring)
        {
            var dataEntity = GetEntity(TransformUsageFlags.None);
            AddComponent(dataEntity, new DataProperties()
                {
                    EnemyPrefab = GetEntity(authoring.enemyPrefab, TransformUsageFlags.None),
                    BulletPrefab = GetEntity(authoring.bulletPrefab, TransformUsageFlags.None),
                    EnemySpeed = authoring.enemySpeed,
                    EnemyDamage = authoring.enemyDamage,
                    BulletSpeed = authoring.bulletSpeed
                });
            AddComponent(dataEntity, new DataRandom()
            {   
                Value = Random.CreateFromIndex(authoring.randomSeed)
            });
        }
    
    }
}