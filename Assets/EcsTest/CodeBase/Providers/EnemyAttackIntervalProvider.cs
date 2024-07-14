using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers
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