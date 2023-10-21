using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Script.DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnEnemySystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DataProperties>();
            state.RequireForUpdate<EnemySpawnTimer>();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var dataEntity = SystemAPI.GetSingletonEntity<DataProperties>();
            var dataAspect = SystemAPI.GetAspect<DataAspect>(dataEntity);

            var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();

            new SpawnEnemyJob()
            {
                DeltaTime = deltaTime,
                ECB = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged)
            }.Run();
        }
    }

    [BurstCompile]
    public partial struct SpawnEnemyJob : IJobEntity
    {
        public float DeltaTime;
        public EntityCommandBuffer ECB;

        [BurstCompile]
        private void Execute(DataAspect dataAspect)
        {
            dataAspect.EnemySpawnTimer -= DeltaTime;
            if (!dataAspect.TimeToSpawnWave)
            {
                return;
            }

            for (int i = 0; i < dataAspect.NumberToSpawn; i++)
            {
                var newEnemy = ECB.Instantiate(dataAspect.EnemyPrefab);
                ECB.SetComponent(newEnemy, dataAspect.GetRandomEnemyTransform());
            }

            dataAspect.EnemySpawnTimer = dataAspect.SpawnRate;
        }
    }
}