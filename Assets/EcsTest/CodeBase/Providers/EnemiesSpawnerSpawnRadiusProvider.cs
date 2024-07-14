using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers
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