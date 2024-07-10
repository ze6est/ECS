using EcsTest.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.UnityComponents
{
    public class Fireball : MonoBehaviour
    {
        private EcsEntity _entity;

        public void SetEntity(EcsEntity entity) => 
            _entity = entity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterController>())
                return;

            _entity.Get<FireballDestroyEvent>();
        }
    }
}