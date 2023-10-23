using Unity.Entities;
using UnityEngine;

namespace Script.DOTS
{
    public class PlayerAuthoring : MonoBehaviour
    {
        public float movementSpeed;
        public float rotationSpeed;
    }

    public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            var playerEntity = GetEntity(TransformUsageFlags.Dynamic);
        
            AddComponent<PlayerMoveInput>(playerEntity);
            AddComponent(playerEntity, new PlayerMovementParams()
            {
                MovementSpeed = authoring.movementSpeed,
                RotationSpeed = authoring.rotationSpeed
            });
        }
    }
}