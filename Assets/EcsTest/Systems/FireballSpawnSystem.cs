using EcsTest.Components;
using EcsTest.UnityComponents;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class FireballSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly PlayerConfigs _configs = null;
        
        private readonly EcsFilter<PlayerShootEvent, FireballSpawnPosition, TransformComponent> _players = null;
        
        public void Run()
        {
            foreach (int entity in _players)
            {
                FireballSpawnPosition fireballSpawnPosition = _players.Get2(entity);
                TransformComponent transformComponent = _players.Get3(entity);

                Transform spawnPosition = fireballSpawnPosition.SpawnPosition;
                Transform transform = transformComponent.Transform;
                
                EcsEntity newEntity = _ecsWorld.NewEntity();
                ref FireballComponent fireballComponent = ref newEntity.Get<FireballComponent>();
                newEntity.Get<FireballSpeed>().Speed = _configs.FireballSpeed;

                Fireball fireball = Object.Instantiate(_configs.FireballPrefab, spawnPosition.position, transform.rotation);
                fireball.SetEntity(newEntity);
                fireballComponent.Fireball = fireball;
                
                _players.GetEntity(entity).Del<PlayerShootEvent>();
            }
        }
    }
}