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
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            var dataEntity = SystemAPI.GetSingletonEntity<DataProperties>();
            var dataAspect = SystemAPI.GetAspect<DataAspect>(dataEntity);

            var ecb = new EntityCommandBuffer(Allocator.Temp);
            
            for (int i = 0; i < dataAspect.NumberToSpawn; i++)
            {
                var newEntity = ecb.Instantiate(dataAspect.EnemyPrefab);
                ecb.SetComponent(newEntity, dataAspect.GetRandomEnemyTransform());
            }
            
            ecb.Playback(state.EntityManager);

        }
    }
}