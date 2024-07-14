using EcsTest.CodeBase.Components;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyProvider : MonoProvider<RigidbodyComponent>{}
}