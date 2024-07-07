using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct LookToMouseComponent
    {
        public Vector2 MousePosition;
    }
}