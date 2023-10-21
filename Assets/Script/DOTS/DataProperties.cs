using Unity.Entities;

namespace Script.DOTS
{
    public struct DataProperties : IComponentData
    {
        public Entity EnemyPrefab;
        public Entity BulletPrefab;

        public float EnemySpeed;
        public int EnemyDamage;

        public float BulletSpeed;

        public float SpawnTimer;
        public int NumberToSpawn;
        public float SpawnRadius;
    }

    public struct EnemySpawnTimer : IComponentData
    {
        public float Value;
    }
}