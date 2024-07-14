using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Configs;
using EcsTest.CodeBase.Systems;
using EcsTest.CodeBase.Systems.Enemies;
using EcsTest.CodeBase.Systems.FireballSystem;
using EcsTest.CodeBase.Systems.Input;
using EcsTest.CodeBase.Systems.PlayerSystem;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest {
    sealed class EcsStartupTest : MonoBehaviour
    {
        [SerializeField] private GameConfigs _gameConfigs;
        [SerializeField] private SceneData _sceneData;
        
        private EcsWorld _world;
        private EcsSystems _fixedUpdateSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;

        private InputActions _inputActions;

        private void Start () 
        {
            _world = new EcsWorld ();

            _fixedUpdateSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems (_world);
            _lateUpdateSystems = new EcsSystems(_world);

            _inputActions = new InputActions();
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_fixedUpdateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_lateUpdateSystems);
#endif
            _fixedUpdateSystems.ConvertScene();
            _updateSystems.ConvertScene();
            _lateUpdateSystems.ConvertScene();
            
            AddSystems();

            AddOneFrames();
            
            InjectSystems();

            InitSystems();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void Update () 
        {
            _updateSystems?.Run ();
        }

        private void LateUpdate()
        {
            _lateUpdateSystems?.Run();
        }

        private void OnDestroy () 
        {
            if (_fixedUpdateSystems !=null && _updateSystems != null && _lateUpdateSystems != null) 
            {
                _fixedUpdateSystems.Destroy();
                _updateSystems.Destroy ();
                _lateUpdateSystems.Destroy();

                _fixedUpdateSystems = null;
                _updateSystems = null;
                _lateUpdateSystems = null;
                
                _world.Destroy ();
                _world = null;
            }
        }

        private void AddSystems()
        {
            _fixedUpdateSystems
                .Add(new EnemyFollowSystem());

            _updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerShotInputSystem())
                .Add(new LookToSystems())
                .Add(new PlayerMovementSystem())
                .Add(new EnemiesSpawnSystem())
                .Add(new EnemiesSetDirectionSystem())
                .Add(new EnemiesLookToSystem())
                .Add(new EnemyAttackSystems())
                .Add(new PlayerShotSystem())
                .Add(new FireballSpawnSystem())
                .Add(new FireballMoveSystem())
                .Add(new EntityInitializeSystem())
                .Add(new DestroySystems())
                .Add(new PlayerDamageSystem());

            _lateUpdateSystems
                .Add(new CameraFollowSystem());
        }

        private void AddOneFrames()
        {
            _updateSystems
                .OneFrame<InitializeEntityRequest>()
                .OneFrame<AttackedEvent>();
        }

        private void InjectSystems()
        {
            _fixedUpdateSystems
                .Inject(_gameConfigs)
                .Inject(_inputActions)
                .Inject(_sceneData);
                
            _updateSystems
                .Inject(_gameConfigs)
                .Inject(_inputActions)
                .Inject(_sceneData);
            
            _lateUpdateSystems
                .Inject(_gameConfigs)
                .Inject(_inputActions)
                .Inject(_sceneData);
        }

        private void InitSystems()
        {
            _fixedUpdateSystems.Init();
            _updateSystems.Init();
            _lateUpdateSystems.Init();
        }
    }
}