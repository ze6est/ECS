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

        private readonly EcsFilter<PlayerTag, SpeedComponent> _playersFilter;

        public void Init()
        {
            Object.Instantiate(_playerConfigs.Prefab, _playerConfigs.StartPoint, Quaternion.identity);
            
            foreach (int entity in _playersFilter)
            {
                ref SpeedComponent speedComponent = ref _playersFilter.Get2(entity);
                speedComponent.Speed = _playerConfigs.Speed;
            }
        }
    }
}