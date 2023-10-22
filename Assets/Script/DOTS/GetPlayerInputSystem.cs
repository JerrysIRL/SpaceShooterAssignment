using Unity.Entities;
using UnityEngine;

namespace Script.DOTS
{
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
    public partial class GetPlayerInput : SystemBase
    {
        private Entity _playerEntity;
        private PlayerControls _playerControls;

        protected override void OnCreate()
        {
            RequireForUpdate<PlayerMoveInput>();
            _playerControls = new PlayerControls();
        }

        protected override void OnUpdate()
        {
            Vector2 moveInput = _playerControls.PlayerActionMap.Movement.ReadValue<Vector2>();
            
            SystemAPI.SetSingleton(new PlayerMoveInput{ Value = moveInput});
        }

        protected override void OnStartRunning()
        {
            _playerControls.Enable();
        }

        protected override void OnStopRunning()
        {
            _playerControls.Disable();
            _playerEntity = Entity.Null;
        }
    }
}
