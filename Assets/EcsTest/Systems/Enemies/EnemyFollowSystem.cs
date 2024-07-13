using EcsTest.Components;
using EcsTest.Components.Enemies;
using EcsTest.Components.PlayerComponents;
using EcsTest.UnityComponents.Configs;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.Systems.Enemies
{
    public class EnemyFollowSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EnemyTag, TransformComponent, RigidbodyComponent> _enemies = null;
        private readonly EcsFilter<PlayerTag, TransformComponent> _players = null;
        
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
                ref TransformComponent transformComponent = ref _enemies.Get2(entity);
                RigidbodyComponent rigidbodyComponent = _enemies.Get3(entity);
                
                ref Transform enemyTransform = ref transformComponent.Transform;
                Rigidbody enemyRigidbody = rigidbodyComponent.Rigidbody;

                if (playerTransform != null)
                {
                    float distanceToPlayer = (playerTransform.position - enemyTransform.position).sqrMagnitude;

                    if (distanceToPlayer > _gameConfigs.EnemyAttackDistance * _gameConfigs.EnemyAttackDistance)
                    {
                        enemyRigidbody.AddForce(enemyTransform.forward * _gameConfigs.EnemySpeed);
                        
                        if (enemyRigidbody.velocity.sqrMagnitude > _gameConfigs.EnemySpeed * _gameConfigs.EnemySpeed) 
                        {
                            enemyRigidbody.velocity = enemyRigidbody.velocity.normalized * _gameConfigs.EnemySpeed;
                        }
                        
                        //enemyRigidbody.velocity = enemyTransform.forward * _gameConfigs.EnemySpeed;
                    } 
                    else 
                    {
                        enemyRigidbody.velocity = Vector3.zero;
                    }
                }
            }
        }
    }
}