using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private PlayerConfigs _playerConfigs;
        private SceneData _sceneData;

        private readonly EcsFilter<PlayerTag, SpeedComponent> _playersFilter;
        
        public void Init()
        {
            Object.Instantiate(_playerConfigs.Prefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
        }
    }
}