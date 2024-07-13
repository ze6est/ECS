using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class EnemyAttackIntervalProvider : MonoProvider<IntervalComponent>
    {
        [SerializeField] private GameConfigs _gameConfigs;

        private void Awake()
        {
            value.Interval = _gameConfigs.EnemyAttackInterval;
        }
    }
}