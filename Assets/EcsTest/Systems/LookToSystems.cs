using EcsTest.Components;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class LookToSystems : IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, LookDirection> _lookDirectionFilter;

        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (int i in _lookDirectionFilter)
            {
                ref TransformComponent transformComponent = ref _lookDirectionFilter.Get1(i);
                ref LookDirection lookDirection = ref _lookDirectionFilter.Get2(i);
                
                ref Transform transform = ref transformComponent.Transform;
                ref Vector2 lookPosition = ref lookDirection.LookPosition;
                
                Plane plane = new Plane(Vector3.up, transform.position);
                Ray ray = _sceneData.CameraMain.ScreenPointToRay(lookPosition);
                if (!plane.Raycast(ray, out var hitDistance)) continue;

                transform.forward = ray.GetPoint(hitDistance) - transform.position;
            }
        }
    }
}