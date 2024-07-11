using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers.PlayerProviders
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