using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Script.DOTS
{
    [BurstCompile]
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct ProjectileMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DataProperties>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var dataEntity = SystemAPI.GetSingletonEntity<DataProperties>();
            var dataAspect = SystemAPI.GetAspect<DataAspect>(dataEntity);
            var deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(state.WorldUnmanaged);
            
            foreach (var (projectile, projEntity) in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<ProjectileTag>().WithEntityAccess())
            {
                var newPos = projectile.ValueRO.Position + projectile.ValueRO.Up() * dataAspect.ProjectileSpeed * deltaTime;
                if (math.abs(newPos.x) > 10 || math.abs(newPos.y) > 10)
                {
                    ecb.DestroyEntity(projEntity);
                }
                else
                {
                    projectile.ValueRW.Position = newPos;
                }
            }
        }
    }
    
}
