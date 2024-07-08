using EcsTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<PlayerTag, Movable> _moveDirectionFilter = null;
        
        private InputActions _inputActions;

        private Vector2 _moveDirectionNormalized;
        
        public void Init()
        {
            _inputActions.Player.Enable();
        }
        
        public void Run()
        {
            SetMoveDirection();
            
            foreach (int entity in _moveDirectionFilter)
            {
                ref Movable direction = ref _moveDirectionFilter.Get2(entity);
                ref Vector2 moveDirectionNormalized = ref direction.MoveDirectionNormalized;

                moveDirectionNormalized = _moveDirectionNormalized;
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
    }
}