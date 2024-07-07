using UnityEngine;

namespace ECS.Data
{
    [CreateAssetMenu(menuName = "Static Data")]
    public class StaticData : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public float PlayerSpeed;
    }
}
