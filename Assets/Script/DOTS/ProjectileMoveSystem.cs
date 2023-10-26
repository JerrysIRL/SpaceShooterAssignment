using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Script.DOTS
{
    [BurstCompile]
    [UpdateAfter(typeof(ProjectileSpawningSystem))]
    public partial struct ProjectileMoveSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<DataAspect>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var dataEntity = SystemAPI.GetSingletonEntity<DataAspect>();
            var dataAspect = SystemAPI.GetAspect<DataAspect>(dataEntity);
            var deltaTime = SystemAPI.Time.DeltaTime;

            foreach (var projectile in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<ProjectileTag>())
            {
                projectile.ValueRW = new LocalTransform()
                {
                    Position = projectile.ValueRO.Up() * dataAspect.ProjectileSpeed * deltaTime,
                    Rotation = quaternion.identity,
                    Scale = 1f
                };
            }
        }
    }
    
}
