using EcsTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<PlayerTag, Movable> _moveDirectionFilter = null;
        private readonly EcsFilter<PlayerTag, LookDirection> _lookDirectionFilter = null;
        
        private InputActions _inputActions;

        private Vector2 _moveDirectionNormalized;
        private Vector2 _lookPosition;
        
        public void Init()
        {
            _inputActions.Player.Enable();
        }
        
        public void Run()
        {
            SetMoveDirection();
            SetLookPosition();
            
            foreach (int entity in _moveDirectionFilter)
            {
                ref Movable direction = ref _moveDirectionFilter.Get2(entity);
                ref Vector2 moveDirectionNormalized = ref direction.MoveDirectionNormalized;

                moveDirectionNormalized = _moveDirectionNormalized;
            }

            foreach (int entity in _lookDirectionFilter)
            {
                ref LookDirection lookDirection = ref _lookDirectionFilter.Get2(entity);
                ref Vector2 lookPosition = ref lookDirection.LookPosition;

                lookPosition = _lookPosition;
            }
        }

        public void Destroy()
        {
            _inputActions.Player.Disable();
        }

        private void SetMoveDirection()
        {
            _moveDirectionNormalized = _inputActions.Player.MoveDirection.ReadValue<Vector2>();
        }

        private void SetLookPosition()
        {
            _lookPosition = _inputActions.Player.LookPosition.ReadValue<Vector2>();
        }
    }
}