using System;

namespace EcsTest.CodeBase.Components
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference EntityReference;
    }
}