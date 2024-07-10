using EcsTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerMovementSystem :IEcsRunSystem
    {
        private readonly EcsWorld _world;
        
        private readonly EcsFilter<PlayerTag, PlayerSpeed> _playersSpeedFilter;
        private readonly EcsFilter<PlayerTag, Player, TransformComponent , Movable> _playersFilter = null;
        
        public void Run()
        {
            foreach (int entity in _playersFilter)
            {
                ref Player player = ref _playersFilter.Get2(entity);
                ref TransformComponent transformComponent = ref _playersFilter.Get3(entity);
                ref Movable movable = ref _playersFilter.Get4(entity);
                ref PlayerSpeed playerSpeed = ref _playersSpeedFilter.Get2(entity);

                ref CharacterController characterController = ref player.CharacterController;
                ref Transform transform = ref transformComponent.Transform;
                ref Vector2 moveDirectionNormalized = ref movable.MoveDirectionNormalized;

                Vector3 direction = (transform.forward * moveDirectionNormalized.y) +
                                    (transform.right * moveDirectionNormalized.x);
                
                characterController.Move(direction * playerSpeed.Speed * Time.deltaTime);
            }
        }
    }
}