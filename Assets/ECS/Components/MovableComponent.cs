using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MovableComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
}