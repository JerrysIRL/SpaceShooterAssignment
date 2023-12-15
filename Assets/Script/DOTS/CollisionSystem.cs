using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Script.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateBefore(typeof(EnemyMoveSystem))]
    [BurstCompile]
    public partial struct CollisionSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<ProjectileTag>();
            state.RequireForUpdate<EnemyTag>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var projectile in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<ProjectileTag>())
            {
                foreach (var (enemy, entity) in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<EnemyTag>().WithEntityAccess())
                {
                    if (math.distancesq(projectile.ValueRO.Position, enemy.ValueRO.Position) < 0.05f)
                    {
                        SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged).DestroyEntity(entity);
                    }
                }
            }
        }
    }
}