using Unity.Entities;
using Unity.VisualScripting;
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
            RequireForUpdate<PlayerInput>();
            _playerControls = new PlayerControls();
        }

        protected override void OnUpdate()
        {
            Vector2 moveInput = _playerControls.PlayerActionMap.Movement.ReadValue<Vector2>();
            bool shootButton = _playerControls.PlayerActionMap.Shoot.IsPressed();
            
            SystemAPI.SetSingleton(new PlayerInput
            {
                MoveVector = moveInput,
                IsShooting = shootButton
            });
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
