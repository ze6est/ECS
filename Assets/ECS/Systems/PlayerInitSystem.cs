using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;
        
        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();
            
            ref MovableComponent playerMovable = ref playerEntity.Get<MovableComponent>();
            
            playerMovable.Speed = _staticData.PlayerSpeed;
            
            GameObject player = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
        }
    }
}
