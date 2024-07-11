using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using UnityEngine.Serialization;
using Voody.UniLeo;

namespace EcsTest.Providers.FireballProviders
{
    public class FireballSpeedProvider : MonoProvider<SpeedComponent>
    {
        [FormerlySerializedAs("_playerConfigs")] [SerializeField] private GameConfigs gameConfigs;
        
        private void Awake()
        {
            value.Speed = gameConfigs.FireballSpeed;
        }
    }
}