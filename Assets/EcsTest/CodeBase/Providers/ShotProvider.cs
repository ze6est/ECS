using EcsTest.CodeBase.Components;
using Voody.UniLeo;

namespace EcsTest.CodeBase.Providers
{
    public class ShotProvider : MonoProvider<Shot>
    {
        private void Awake()
        {
            value.Interval = 0;
        }
    }
}