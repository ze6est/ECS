using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class EnemiesSpawnerSpawnRadiusProvider : MonoProvider<RadiusComponent>
    {
        [SerializeField] private GameConfigs _gameConfigs;
        
        private void Awake()
        {
            value.Radius = _gameConfigs.EnemiesSpawnRadius;
        }
    }
}