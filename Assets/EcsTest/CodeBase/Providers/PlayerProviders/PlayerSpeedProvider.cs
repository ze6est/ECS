using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers.PlayerProviders
{
    public class PlayerSpeedProvider : MonoProvider<SpeedComponent>
    {
        [SerializeField] private GameConfigs _gameConfigs;
        
        private void Awake()
        {
            value.Speed = _gameConfigs.PlayerSpeed;
        }
    }
}