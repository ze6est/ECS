using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.PlayerComponents;
using Leopotam.Ecs;

namespace EcsTest.CodeBase.Systems.Input
{
    public class PlayerShotInputSystem : IEcsRunSystem
    {
        private readonly InputActions _inputActions;
        
        private readonly EcsFilter<PlayerTag, Shot> _players = null;
        
        public void Run()
        {
            foreach (int entity in _players)
            {
                ref Shot shot = ref _players.Get2(entity);

                ref var isShot = ref shot.IsShoot;

                isShot = _inputActions.Player.Shoot.IsPressed();
            }
        }
    }
}