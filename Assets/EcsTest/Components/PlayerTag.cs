using System;
using Leopotam.Ecs;

namespace EcsTest.Components
{
    [Serializable]
    public struct PlayerTag : IEcsIgnoreInFilter{}
}