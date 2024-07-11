using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class EnemiesSpawnerIntervalProvider : MonoProvider<IntervalComponent>
    {
        [SerializeField] private GameConfigs _gameConfigs;
        
        private void Awake()
        {
            value.Interval = _gameConfigs.EnemiesSpawnInterval;
        }
    }
}