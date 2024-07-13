using EcsTest.Components;
using EcsTest.Components.Enemies;
using EcsTest.Components.PlayerComponents;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems.Enemies
{
    public class EnemiesSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemiesSpawnerTag, IntervalComponent, RadiusComponent> _enemiesSpawner = null;
        private readonly EcsFilter<PlayerTag, TransformComponent> _players = null;
        
        private GameConfigs _configs;
        
        public void Run()
        {
            foreach (int entity in _players)
            {
                ref IntervalComponent intervalComponent = ref _enemiesSpawner.Get2(entity);
                ref var interval = ref intervalComponent.Interval;

                interval -= Time.deltaTime;

                if (interval <= 0)
                {
                    TransformComponent playerTransformComponent = _players.Get2(entity);
                    Transform playerTransform = playerTransformComponent.Transform;

                    var radiusComponent = _enemiesSpawner.Get3(entity);
                    var radius = radiusComponent.Radius;
                    
                    float angle = Random.Range(0f, Mathf.PI * 2);
                    
                    Vector3 spawnPosition = playerTransform.position + new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);

                    Object.Instantiate(_configs.EnemyPrefab, spawnPosition, Quaternion.identity);

                    interval = _configs.EnemiesSpawnInterval;
                }
            }
        }
    }
}