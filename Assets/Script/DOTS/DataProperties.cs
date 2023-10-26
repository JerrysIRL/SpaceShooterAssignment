using Unity.Entities;
using Unity.Transforms;

namespace Script.DOTS
{
    public struct DataProperties : IComponentData
    {
        public Entity EnemyPrefab;
        public Entity BulletPrefab;

        public float EnemySpeed;
        public int EnemyDamage;

        public float BulletSpeed;
        public float ProjectileSpawnRate;

        public float SpawnRate;
        public int NumberToSpawn;
        public float SpawnRadius;
        public LocalTransform PlayerTransform;
    }

    public struct EnemySpawnTimer : IComponentData
    {
        public float Value;
    }
    
    public struct ProjectileSpawnTimer : IComponentData
    {
        public float Value;
    }
}