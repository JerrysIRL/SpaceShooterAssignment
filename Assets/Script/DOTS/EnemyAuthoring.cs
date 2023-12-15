using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Script.DOTS
{
    public class EnemyAuthoring : MonoBehaviour
    {
        public float movingSpeed = 1f;
    }

    public class EnemyBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(entity, new EnemyTag());
            AddComponent(entity, new EnemySpeed()
            {
                Value = authoring.movingSpeed
            });
        }
    }

    public readonly partial struct EnemyAspect : IAspect
    {
        public readonly Entity Entity;
        private readonly RefRW<LocalTransform> _transform;
        private readonly RefRO<EnemySpeed> _enemySpeed;

        public float MovementSpeed => _enemySpeed.ValueRO.Value;

        public void Move(LocalTransform playerTransform, float speed, float deltaTime)
        {
            float3 direction = math.normalizesafe(playerTransform.Position - _transform.ValueRW.Position);
            _transform.ValueRW.Position += direction * speed * deltaTime;
        }
    }

    public struct EnemySpeed : IComponentData
    {
        public float Value;
    }

    public struct EnemyTag : IComponentData
    {
    }
}