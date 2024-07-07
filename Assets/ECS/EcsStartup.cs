using ECS.Data;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ECS {
    public sealed class EcsStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _systems;
        
        public StaticData _configuration;
        public SceneData _sceneData;
        public RuntimeData _runtimeData;

        private void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            
            _runtimeData = new RuntimeData();
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();
            
            _systems.Init ();
        }

        private void Update () 
        {
            _systems?.Run ();
        }

        private void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
        
        private void AddInjections()
        {
            _systems
                .Inject(_configuration)
                .Inject(_sceneData)
                .Inject(_runtimeData);
        }

        private void AddOneFrames()
        {
            
        }

        private void AddSystems()
        {
            _systems
                .Add(new PlayerInitSystem())    
                .Add(new PlayerInputSystem())
                .Add(new LookToMouseSystem())
                .Add(new MovementSystem());
        }
    }
}