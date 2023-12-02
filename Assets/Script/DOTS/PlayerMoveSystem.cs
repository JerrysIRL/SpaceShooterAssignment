using System.Runtime.InteropServices;
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
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            
            var camera = Camera.main;
            float screenHorizontalSize = camera.orthographicSize * camera.aspect;
            float screenVerticalSize = camera.orthographicSize;
         
            new PlayerMoveJob
            {
                DeltaTime = deltaTime,
                ScreenHorizontalSize = screenHorizontalSize,
                ScreenVerticalSize = screenVerticalSize
            }.Schedule();
        }
    }
    
    [BurstCompile]
    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;
        public float ScreenHorizontalSize;
        public float ScreenVerticalSize;
        
        [BurstCompile]
        private void Execute(ref LocalTransform transform, in PlayerInput input, PlayerMovementParams movementParams)
        {
            var playerMoveInput = input;
            
            playerMoveInput.MoveVector.x = playerMoveInput.MoveVector.y > -0.99f ? -playerMoveInput.MoveVector.x : playerMoveInput.MoveVector.x;
            
            transform.Position += transform.Up() * playerMoveInput.MoveVector.y * (movementParams.MovementSpeed * DeltaTime);
            transform.Rotation = math.mul(transform.Rotation, quaternion.RotateZ(playerMoveInput.MoveVector.x * (movementParams.RotationSpeed * DeltaTime)));
            transform.Scale = 1f;
            
            //screen wrapping
            if (math.abs(transform.Position.x) > ScreenHorizontalSize)
            {
                transform.Position.x = -transform.Position.x;
            }
            if (math.abs(transform.Position.y) > ScreenVerticalSize)
            {
                transform.Position.y = -transform.Position.y;
            }
            
        }
    }
}
