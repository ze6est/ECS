using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class FireballSpeedProvider : MonoProvider<FireballSpeed>
    {
        [SerializeField] private PlayerConfigs _playerConfigs;
        
        private void Awake()
        {
            value.Speed = _playerConfigs.FireballSpeed;
        }
    }
}