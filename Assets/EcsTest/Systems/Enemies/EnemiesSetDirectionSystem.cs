using EcsTest.Components;
using EcsTest.Components.Enemies;
using EcsTest.Components.PlayerComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems.Enemies
{
    public class EnemiesSetDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, LookDirection> _enemies = null;
        private readonly EcsFilter<PlayerTag, TransformComponent> _players = null;
        
        public void Run()
        {
            Vector3 position = Vector3.zero;
            
            foreach (int entity in _players)
            {
                position = _players.Get2(entity).Transform.position;
            }
            
            foreach (int entity in _enemies)
            {
                ref LookDirection LookDirection = ref _enemies.Get2(entity);
                ref var lookPosition = ref LookDirection.LookPosition;
                lookPosition = new Vector2(position.x, position.z);
            }
        }
    }
}