using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerMovementSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, SpeedComponent> _playersSpeedFilter;
        private readonly EcsFilter<PlayerTag, Player, TransformComponent , Movable> _playersFilter = null;

        private EcsWorld _world;
        private PlayerConfigs _playerConfigs;

        private float _speed;
        
        public void Init()
        {
            foreach (int entity in _playersSpeedFilter)
            {
                ref SpeedComponent speedComponent = ref _playersSpeedFilter.Get2(entity);
                _speed = speedComponent.Speed;
            }
        }
        
        public void Run()
        {
            foreach (int entity in _playersFilter)
            {
                ref Player player = ref _playersFilter.Get2(entity);
                ref var transformComponent = ref _playersFilter.Get3(entity);
                ref Movable movable = ref _playersFilter.Get4(entity);

                ref CharacterController characterController = ref player.CharacterController;
                ref Transform transform = ref transformComponent.Transform;
                ref Vector2 moveDirectionNormalized = ref movable.MoveDirectionNormalized;

                Vector3 direction = (transform.forward * moveDirectionNormalized.y) +
                                    (transform.right * moveDirectionNormalized.x);
                
                characterController.Move(direction * _speed * Time.deltaTime);
            }
        }
    }
}