using Unity.Entities;
using Unity.Mathematics;

namespace Script.DOTS
{
    public struct PlayerInput : IComponentData
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