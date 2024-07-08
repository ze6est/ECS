using EcsTest.Systems;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest {
    sealed class EcsStartupTest : MonoBehaviour
    {
        [SerializeField] private PlayerConfigs _playerConfigs;
        
        EcsWorld _world;
        EcsSystems _systems;

        private InputActions _inputActions;

        private void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);

            _inputActions = new InputActions();
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems.ConvertScene();
            
            _systems
                .Inject(_playerConfigs)
                .Inject(_inputActions)    
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                .Init ();
        }

        private void Update () 
        {
            _systems?.Run ();
        }

        private void OnDestroy () 
        {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}