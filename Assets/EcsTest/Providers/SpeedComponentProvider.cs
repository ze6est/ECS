using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class SpeedComponentProvider : MonoProvider<SpeedComponent>
    {
        [SerializeField] private PlayerConfigs _playerConfigs;
        
        private void Awake()
        {
            value.Speed = _playerConfigs.Speed;
        }
    }
}