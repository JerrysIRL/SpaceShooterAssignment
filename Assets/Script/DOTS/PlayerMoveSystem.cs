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
        private void Execute(ref LocalTransform transform, in PlayerMoveInput moveInput, PlayerMovementParams movementParams)
        {
            var playerMoveInput = moveInput;
            
            playerMoveInput.Value.x = playerMoveInput.Value.y > -0.99f ? -playerMoveInput.Value.x : playerMoveInput.Value.x;
            
            transform.Position += transform.Up() * playerMoveInput.Value.y * (movementParams.MovementSpeed * DeltaTime);
            transform.Rotation = math.mul(transform.Rotation, quaternion.RotateZ(playerMoveInput.Value.x * (movementParams.RotationSpeed * DeltaTime)));
            transform.Scale = 1f;
        }
    }
}
