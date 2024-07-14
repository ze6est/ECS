using EcsTest.CodeBase.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase
{
    public class Fireball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if(enemy.TryGetComponent(out EntityReference enemyEntityReference))
                {
                    EcsEntity enemyEntity = enemyEntityReference.Entity;
                    enemyEntity.Get<DestroyEvent>();
                    enemy.gameObject.SetActive(false);
                }
                
                if (TryGetComponent(out EntityReference fireballEntityReference))
                {
                    EcsEntity fireballEntity = fireballEntityReference.Entity;
                    fireballEntity.Get<DestroyEvent>();
                    gameObject.SetActive(false);
                }
            }
        }
    }
}