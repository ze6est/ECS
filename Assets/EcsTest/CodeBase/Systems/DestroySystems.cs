using EcsTest.CodeBase.Components;
using Leopotam.Ecs;

namespace EcsTest.CodeBase.Systems
{
    public class DestroySystems : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyEvent> _destroyFilter = null;
        
        public void Run()
        {
            foreach (int index in _destroyFilter)
            {
                ref EcsEntity entity = ref _destroyFilter.GetEntity(index);
                
                entity.Destroy();
            }
        }
    }
}