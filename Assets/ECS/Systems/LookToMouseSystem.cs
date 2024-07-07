using ECS.Components;
using ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class LookToMouseSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, LookToMouseComponent> _lookToMouseFilter;

        private SceneData _sceneData;
        
        public void Run()
        {
            foreach (int i in _lookToMouseFilter)
            {
                ref ModelComponent modelComponent = ref _lookToMouseFilter.Get1(i);
                ref LookToMouseComponent lookToMouseComponent = ref _lookToMouseFilter.Get2(i);
                
                ref Transform transform = ref modelComponent.ModelTransform;
                ref Vector2 mousePosition = ref lookToMouseComponent.MousePosition;
                
                Plane playerPlane = new Plane(Vector3.up, transform.position);
                Ray ray = _sceneData.CameraMain.ScreenPointToRay(mousePosition);
                if (!playerPlane.Raycast(ray, out var hitDistance)) continue;

                transform.forward = ray.GetPoint(hitDistance) - transform.position;
            }
        }
    }
}
