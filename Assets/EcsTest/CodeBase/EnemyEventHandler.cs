using System;
using EcsTest.CodeBase.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace EcsTest.CodeBase
{
    public class EnemyEventHandler : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        private void Awake()
        {
            _triggerObserver.PlayerAttacked += OnPlayerAttacked;
        }

        private void OnDestroy()
        {
            _triggerObserver.PlayerAttacked -= OnPlayerAttacked;
        }

        private void OnPlayerAttacked(Player player)
        {
            if (player.TryGetComponent(out EntityReference playerEntityReference))
            {
                EcsEntity playerEntity = playerEntityReference.Entity;
                playerEntity.Get<AttackedEvent>();
            }
        }
    }
}