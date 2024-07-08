using UnityEngine;

namespace EcsTest.UnityComponents.Configs
{
    [CreateAssetMenu(menuName = "Player Configs", fileName = "PlayerConfigs")]
    public class PlayerConfigs : ScriptableObject
    {
        public GameObject Prefab;
        public float Speed;
    }
}