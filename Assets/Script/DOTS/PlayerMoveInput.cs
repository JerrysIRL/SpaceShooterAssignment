using Unity.Entities;
using Unity.Mathematics;

namespace Script.DOTS
{
    public struct PlayerMoveInput : IComponentData
    {
        public float2 MoveVector;
        public bool IsShooting;
    }

    public struct PlayerMovementParams : IComponentData
    {
        public float MovementSpeed;
        public float RotationSpeed;
    }
}
