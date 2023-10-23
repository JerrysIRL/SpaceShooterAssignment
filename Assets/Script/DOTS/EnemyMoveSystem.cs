using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Script.DOTS
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(SpawnEnemySystem))]
    public partial struct EnemyMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DataProperties>();
            state.RequireForUpdate<PlayerMovementParams>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            
            var player = SystemAPI.GetSingletonEntity<PlayerMovementParams>();
            var playerTranform = SystemAPI.GetComponentRO<LocalTransform>(player).ValueRO;
            
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            new MoveEnemyJob()
            {
                DeltaTime = deltaTime,
                PlayerTransform = playerTranform
            }.ScheduleParallel();

            // foreach (var enemy in SystemAPI.Query<EnemyAspect>().WithAll<EnemyTag>())
            // {
            //    enemy.Move(playerTranform, dataProperties.EnemySpeed, deltaTime);
            // }
        }
        
        
    }
    
    [BurstCompile]
    public partial struct MoveEnemyJob : IJobEntity
    {
        public float DeltaTime;
        public LocalTransform PlayerTransform;

        private void Execute(EnemyAspect enemy)
        {
            enemy.Move(PlayerTransform, enemy.MovementSpeed, DeltaTime);
        }
        
    }
}