using EcsTest.Components;
using EcsTest.Components.PlayerComponents;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class CameraFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private SceneData _sceneData;

        private readonly EcsFilter<PlayerTag, TransformComponent> _players = null;

        private Vector3 _offset;
        
        public void Init()
        {
            _offset = _sceneData.CameraMain.transform.position;
        }
        
        public void Run()
        {
            foreach (int entity in _players)
            {
                TransformComponent playerTransformComponent = _players.Get2(entity);
                var playerTransform = playerTransformComponent.Transform;

                _sceneData.CameraMain.transform.position = playerTransform.position + _offset;
            }
            
        }
    }
}