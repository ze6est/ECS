using System;
using UnityEngine;

namespace EcsTest.CodeBase.Components
{
    [Serializable]
    public struct Movable
    {
        public Vector2 MoveDirectionNormalized;
    }
}