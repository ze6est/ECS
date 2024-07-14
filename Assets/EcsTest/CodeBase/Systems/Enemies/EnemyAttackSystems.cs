using EcsTest.CodeBase.Components;
using EcsTest.CodeBase.Components.Enemies;
using EcsTest.CodeBase.Components.PlayerComponents;
using EcsTest.CodeBase.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase.Systems.Enemies
{
    public class EnemyAttackSystems : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, TransformComponent, AnimatorComponent, IntervalComponent> _enemies = null;
        private readonly EcsFilter<PlayerTag, TransformComponent, Health> _players = null;
        
        private GameConfigs _gameConfigs;
        
        public void Run()
        {
            Transform playerTransform = null;
            
            foreach (int entity in _players)
            {
                TransformComponent transformComponent = _players.Get2(entity);
                playerTransform = transformComponent.Transform;
            }
            
            foreach (int entity in _enemies)
            {
                if (playerTransform != null)
                {
                    ref IntervalComponent intervalComponent = ref _enemies.Get4(entity);
                    ref float attackInterval = ref intervalComponent.Interval;
                    
                    if (attackInterval >= 0)
                    {
                        attackInterval -= Time.deltaTime;
                        continue;
                    }
                    
                    TransformComponent transformComponent = _enemies.Get2(entity);
                    ref AnimatorComponent animatorComponent = ref _enemies.Get3(entity);
                    ref Health health = ref _players.Get3(entity);
                
                    Transform enemyTransform = transformComponent.Transform;
                    ref Animator animator = ref animatorComponent.Animator;
                    
                    float distanceToPlayer = (playerTransform.position - enemyTransform.position).sqrMagnitude;

                    if (distanceToPlayer <= _gameConfigs.EnemyAttackDistance * _gameConfigs.EnemyAttackDistance && health.Value > 0)
                    {
                        animator.SetTrigger("Attack");

                        attackInterval = _gameConfigs.EnemyAttackInterval;
                    } 
                }
            }
        }
    }
}