using EcsTest.Components;
using UnityEngine;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    [RequireComponent(typeof(Rigidbody))]
    public class RigidbodyProvider : MonoProvider<RigidbodyComponent>{}
}