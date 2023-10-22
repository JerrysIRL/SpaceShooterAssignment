using System.Numerics;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Script.DOTS
{
    [UpdateBefore(typeof(TransformSystemGroup))]
    [BurstCompile]
    public partial struct PlayerMoveSystem : ISystem
    {
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new PlayerMoveJob
            {
                DeltaTime = deltaTime
            }.Schedule();
        }
    }
    
    [BurstCompile]
    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute(ref LocalTransform transform, in PlayerMoveInput moveInput, PlayerMovementParams movementParams)
        {
            var playerMoveInput = moveInput;
            transform.Position += transform.Up() * playerMoveInput.Value.y * (movementParams.MovementSpeed * DeltaTime);
            playerMoveInput.Value.x = playerMoveInput.Value.y > -0.99f ? -playerMoveInput.Value.x : playerMoveInput.Value.x;
            quaternion tmpRotation = transform.Rotation;
            tmpRotation = math.mul(tmpRotation, quaternion.RotateZ(playerMoveInput.Value.x * (movementParams.RotationSpeed * DeltaTime)));
            transform.Rotation = tmpRotation;
            transform.Scale = 1f;
        }
    }
}
