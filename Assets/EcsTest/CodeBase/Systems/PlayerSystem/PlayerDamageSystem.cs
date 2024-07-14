using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.PlayerComponents;
using EcsTest.CodeBase.Configs;
using Leopotam.Ecs;

namespace EcsTest.CodeBase.Systems.PlayerSystem
{
    public class PlayerDamageSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, AttackedEvent, Health> _attackedFilter;

        private GameConfigs _gameConfigs;
        
        public void Run()
        {
            foreach (int index in _attackedFilter)
            {
                ref var entity = ref _attackedFilter.GetEntity(index);
                
                ref Health health = ref _attackedFilter.Get3(index);
                health.Value -= _gameConfigs.EnemyDamage;

                if (health.Value <= 0)
                {
                    entity.Get<DestroyEvent>();
                }
            }
        }
    }
}