using System;
using UnityEngine;

namespace EcsTest.Components
{
    [Serializable]
    public struct Movable
    {
        public Vector2 MoveDirectionNormalized;
    }
}