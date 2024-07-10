using UnityEngine;

namespace EcsTest.UnityComponents.Configs
{
    [CreateAssetMenu(menuName = "Player Configs", fileName = "PlayerConfigs")]
    public class PlayerConfigs : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public Fireball FireballPrefab;
        public float PlayerSpeed;
        public float ShootInterval;
        public float FireballSpeed;
    }
}