using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Script.DOTS
{
    public readonly partial struct DataAspect : IAspect
    {
        public readonly Entity Entity;
        
        private readonly RefRO<DataProperties> _dataProperties;
        private readonly RefRW<DataRandom> _dataRandom;
        private readonly RefRW<EnemySpawnTimer> _spawnTimer;

        public Entity EnemyPrefab => _dataProperties.ValueRO.EnemyPrefab;
        public int EnemyDamage => _dataProperties.ValueRO.EnemyDamage;
        public int NumberToSpawn => _dataProperties.ValueRO.NumberToSpawn;
        public float SpawnRate => _dataProperties.ValueRO.SpawnRate;

        public float EnemySpawnTimer
        {
            get => _spawnTimer.ValueRO.Value;
            set => _spawnTimer.ValueRW.Value = value;
        }

        public bool TimeToSpawnWave => EnemySpawnTimer <= 0f;
        public LocalTransform GetRandomEnemyTransform()
        {
            return new LocalTransform()
            {
                Position = GetRandomPosition(),
                Rotation = quaternion.identity,
                Scale = 1f
            };
        }
        
        private float3 GetRandomPosition()
        {
            float3 randomPosition;
            randomPosition = new float3(_dataRandom.ValueRW.Value.NextFloat(-1f,1f), _dataRandom.ValueRW.Value.NextFloat(-1f,1f), 0);
            randomPosition = math.normalize(randomPosition) * _dataProperties.ValueRO.SpawnRadius;
            return randomPosition ;
        }
        
        
    }
}