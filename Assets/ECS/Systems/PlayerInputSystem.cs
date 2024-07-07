using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem, IEcsDestroySystem
    {
        private readonly EcsFilter<PlayerTagComponent, DirectionComponent> _directionFilter = null;
        private readonly EcsFilter<PlayerTagComponent, LookToMouseComponent> _lookToMouseFilter = null;

        private InputActions _inputs;

        private Vector2 _move;
        private Vector2 _mousePosition;

        public PlayerInputSystem()
        {
            _inputs = new InputActions();
            _inputs.Player.Enable();
        }
        
        public void Run()
        {
            SetDirection();
            SetMousePosition();
            
            foreach (int i in _directionFilter)
            {
                ref DirectionComponent directionComponent = ref _directionFilter.Get2(i);
                ref Vector2 direction = ref directionComponent.Direction;

                direction = _move;
            }
            
            foreach (int i in _lookToMouseFilter)
            {
                ref LookToMouseComponent lookToMouseComponent = ref _lookToMouseFilter.Get2(i);
                ref Vector2 mousePosition = ref lookToMouseComponent.MousePosition;

                mousePosition = _mousePosition;
            }
        }
        
        public void Destroy()
        {
            _inputs.Player.Disable();
        }

        private void SetDirection()
        {
            _move = _inputs.Player.Move.ReadValue<Vector2>();
        }
        
        private void SetMousePosition()
        {
            _mousePosition = _inputs.Player.DirectionLook.ReadValue<Vector2>();
        }
    }
}