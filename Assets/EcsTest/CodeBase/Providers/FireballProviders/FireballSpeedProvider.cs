using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers.FireballProviders
{
    public class FireballSpeedProvider : MonoProvider<SpeedComponent>
    {
        [SerializeField] private GameConfigs gameConfigs;
        
        private void Awake()
        {
            value.Speed = gameConfigs.FireballSpeed;
        }
    }
}