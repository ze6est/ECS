using EcsTest.CodeBase.Components;
using Leopotam.Ecs;

namespace EcsTest.CodeBase.Systems
{
    public class EntityInitializeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InitializeEntityRequest> _initFilter = null;
        
        public void Run()
        {
            foreach (int index in _initFilter)
            {
                ref EcsEntity entity = ref _initFilter.GetEntity(index);
                ref InitializeEntityRequest request = ref _initFilter.Get1(index);

                request.EntityReference.Entity = entity;
            }
        }
    }
}