using EcsTest.Components;
using Voody.UniLeo;

namespace EcsTest.Providers
{
    public class ShotProvider : MonoProvider<Shot>
    {
        private void Awake()
        {
            value.Interval = 0;
        }
    }
}