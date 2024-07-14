using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.FireballComponents;
using EcsTest.CodeBase.Components.PlayerComponents;
using EcsTest.CodeBase.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase.Systems.FireballSystem
{
    public class FireballSpawnSystem : IEcsRunSystem
    {
        private readonly GameConfigs _configs = null;
        
        private readonly EcsFilter<PlayerShootEvent, FireballSpawnPosition, TransformComponent> _players = null;
        
        private EcsWorld _world;
        
        public void Run()
        {
            foreach (int entity in _players)
            {
                FireballSpawnPosition fireballSpawnPosition = _players.Get2(entity);
                TransformComponent transformComponent = _players.Get3(entity);

                Transform spawnPosition = fireballSpawnPosition.SpawnPosition;
                Transform transform = transformComponent.Transform;
                
                _players.GetEntity(entity).Del<PlayerShootEvent>();

                Object.Instantiate(_configs.FireballPrefab, spawnPosition.position, transform.rotation);
            }
        }
    }
}