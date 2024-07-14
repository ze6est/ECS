using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.PlayerComponents;
using EcsTest.CodeBase.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase.Systems.PlayerSystem
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _ecsWorld;
        private readonly GameConfigs _gameConfigs;
        private readonly SceneData _sceneData;

        private readonly EcsFilter<PlayerTag, SpeedComponent> _playersFilter;
        
        public void Init()
        {
            Object.Instantiate(_gameConfigs.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);
        }
    }
}