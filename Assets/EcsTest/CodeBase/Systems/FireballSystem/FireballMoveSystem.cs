using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.FireballComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase.Systems.FireballSystem
{
    public class FireballMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FireballComponent, SpeedComponent> _fireballs = default;
        
        public void Run()
        {
            foreach (int entity in _fireballs)
            {
                ref var fireballComponent = ref _fireballs.Get1(entity);
                ref var fireballSpeed = ref _fireballs.Get2(entity);

                var transform = fireballComponent.Fireball.transform;

                transform.position += transform.forward * fireballSpeed.Speed * Time.deltaTime;
            }
        }
    }
}