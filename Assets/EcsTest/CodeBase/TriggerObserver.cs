using UnityEngine;
using UnityEngine.Events;

namespace EcsTest.CodeBase
{
    public class TriggerObserver : MonoBehaviour
    {
        public event UnityAction<Player> PlayerAttacked;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                PlayerAttacked?.Invoke(player);
            }
        }
    }
}