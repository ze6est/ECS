using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers.PlayerProviders
{
    public class PlayerHealthProvider : MonoProvider<Health>
    {
        [SerializeField] private GameConfigs _gameConfigs;
        
        private void Awake()
        {
            value.Value = _gameConfigs.PlayerHealth;
        }
    }
}