using EcsTest.Components;
using EcsTest.Components.Enemies;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems.Enemies
{
    public class EnemiesLookToSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, LookDirection, TransformComponent> _enemies = null;
        
        public void Run()
        {
            foreach (int entity in _enemies)
            {
                ref TransformComponent transformComponent = ref _enemies.Get3(entity);
                var lookDirection = _enemies.Get2(entity);
                
                ref Transform transform = ref transformComponent.Transform;
                Vector2 lookPosition = lookDirection.LookPosition;
                
                transform.forward = new Vector3(lookPosition.x, transform.position.y, lookPosition.y) - transform.position;
            }
        }
    }
}