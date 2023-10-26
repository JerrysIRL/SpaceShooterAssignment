using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


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
        private void Execute(ref LocalTransform transform, in PlayerInput input, PlayerMovementParams movementParams)
        {
            var playerMoveInput = input;
            
            playerMoveInput.MoveVector.x = playerMoveInput.MoveVector.y > -0.99f ? -playerMoveInput.MoveVector.x : playerMoveInput.MoveVector.x;
            
            transform.Position += transform.Up() * playerMoveInput.MoveVector.y * (movementParams.MovementSpeed * DeltaTime);
            transform.Rotation = math.mul(transform.Rotation, quaternion.RotateZ(playerMoveInput.MoveVector.x * (movementParams.RotationSpeed * DeltaTime)));
            transform.Scale = 1f;
        }
    }
}
