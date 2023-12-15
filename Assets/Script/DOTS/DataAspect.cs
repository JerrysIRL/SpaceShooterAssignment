using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.SocialPlatforms;

namespace Script.DOTS
{
    public readonly partial struct DataAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRO<DataProperties> _dataProperties;
        private readonly RefRW<DataRandom> _dataRandom;
        private readonly RefRW<EnemySpawnTimer> _spawnTimer;
        private readonly RefRW<ProjectileSpawnTimer> _projectileSpawnTimer;

        public Entity EnemyPrefab => _dataProperties.ValueRO.EnemyPrefab;
        public Entity ProjectilePrefab => _dataProperties.ValueRO.BulletPrefab;
        public int NumberToSpawn => _dataProperties.ValueRO.NumberToSpawn;
        public float SpawnRate => _dataProperties.ValueRO.SpawnRate;
        public float ProjectileSpawnRate => _dataProperties.ValueRO.ProjectileSpawnRate;
        public float ProjectileSpeed => _dataProperties.ValueRO.BulletSpeed;
        public float EnemySpeed => _dataProperties.ValueRO.EnemySpeed;

        public float EnemySpawnTimer
        {
            get => _spawnTimer.ValueRO.Value;
            set => _spawnTimer.ValueRW.Value = value;
        }

        public float ProjectileSpawnTimer
        {
            get => _projectileSpawnTimer.ValueRO.Value;
            set => _projectileSpawnTimer.ValueRW.Value = value;
        }

        public bool TimeToSpawnWave => EnemySpawnTimer <= 0f;
        public bool TimeToSpawnBullet => ProjectileSpawnTimer <= 0f;

        public LocalTransform GetRandomEnemyTransform()
        {
            return new LocalTransform()
            {
                Position = GetRandomPosition(),
                Rotation = quaternion.identity,
                Scale = 0.31f
            };
        }

        private float3 GetRandomPosition()
        {
            var randomPosition = new float3(_dataRandom.ValueRW.Value.NextFloat(-1f, 1f), _dataRandom.ValueRW.Value.NextFloat(-1f, 1f), 0);
            randomPosition = math.normalize(randomPosition) * _dataProperties.ValueRO.SpawnRadius;
            return randomPosition;
        }
    }
}