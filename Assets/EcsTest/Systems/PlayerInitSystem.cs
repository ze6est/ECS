using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly PlayerConfigs _playerConfigs;
        private readonly SceneData _sceneData;

        private readonly EcsFilter<PlayerTag, PlayerSpeed> _playersFilter;
        
        public void Init()
        {
            Object.Instantiate(_playerConfigs.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
        }
    }
}