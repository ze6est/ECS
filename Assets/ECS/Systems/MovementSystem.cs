using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, MovableComponent, DirectionComponent> _movableFilter = null;
        
        public void Run()
        {
            foreach (int i in _movableFilter)
            {
                ref ModelComponent modelComponent = ref _movableFilter.Get1(i);
                ref MovableComponent movableComponent = ref _movableFilter.Get2(i);
                ref DirectionComponent directionComponent = ref _movableFilter.Get3(i);

                ref Vector2 direction = ref directionComponent.Direction;
                ref Transform transform = ref modelComponent.ModelTransform;

                ref CharacterController characterController = ref movableComponent.CharacterController;
                ref float speed = ref movableComponent.Speed;

                Vector3 rawDirection = (transform.right * direction.x) + (transform.forward * direction.y);

                characterController.Move(rawDirection * speed * Time.deltaTime);
            }
        }
    }
}