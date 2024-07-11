using EcsTest.Systems;
using EcsTest.Systems.Enemies;
using EcsTest.Systems.FireballSystem;
using EcsTest.Systems.Input;
using EcsTest.Systems.PlayerSystem;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest {
    sealed class EcsStartupTest : MonoBehaviour
    {
        [SerializeField] private GameConfigs _gameConfigs;
        [SerializeField] private SceneData _sceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;

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
            
            AddSystems();
            
            InjectSystems();
            
            _systems
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

        private void AddSystems()
        {
            _systems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerShotInputSystem())
                .Add(new LookToSystems())
                .Add(new PlayerMovementSystem())
                .Add(new CameraFollowSystem())
                .Add(new EnemiesSpawnSystem())
                .Add(new EnemiesSetDirectionSystem())
                .Add(new EnemiesLookToSystem())
                .Add(new PlayerShotSystem())
                .Add(new FireballSpawnSystem())
                .Add(new FireballMoveSystem());
        }

        private void InjectSystems()
        {
            _systems
                .Inject(_gameConfigs)
                .Inject(_inputActions)
                .Inject(_sceneData);
        }
    }
}