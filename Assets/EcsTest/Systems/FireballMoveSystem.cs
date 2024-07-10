using EcsTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems
{
    public class FireballMoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FireballComponent, FireballSpeed> _fireballs = default;
        
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