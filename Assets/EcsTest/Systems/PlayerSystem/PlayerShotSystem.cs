using EcsTest.Components;
using EcsTest.Components.PlayerComponents;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems.PlayerSystem 
{
    sealed class PlayerShotSystem : IEcsRunSystem 
    {
        private readonly InputActions _inputActions;
        private readonly GameConfigs _configs;

        private readonly EcsFilter<PlayerTag, Shot> _players = null;
        
        public void Run () 
        {
            if (_players.IsEmpty())
                return;

            foreach (int entity in _players)
            {
                ref Shot shot = ref _players.Get2(entity);

                ref float interval = ref shot.Interval;
                
                if (interval >= 0)
                {
                    interval -= Time.deltaTime;
                    return;
                }

                bool isShot = shot.IsShoot;
                
                if (isShot == false)
                    return;

                EcsEntity currentEntity = _players.GetEntity(entity);
                currentEntity.Get<PlayerShootEvent>();

                interval = _configs.PlayerShootInterval;
            }
        }
    }
}