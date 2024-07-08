using UnityEngine;

namespace EcsTest.UnityComponents.Configs
{
    [CreateAssetMenu(menuName = "Player Configs", fileName = "PlayerConfigs")]
    public class PlayerConfigs : ScriptableObject
    {
        public GameObject Prefab;
        public Vector3 StartPoint;
        public float Speed;
    }
}