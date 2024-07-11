using UnityEngine;

namespace EcsTest.UnityComponents.Configs
{
    [CreateAssetMenu(menuName = "Configs", fileName = "Configs")]
    public class GameConfigs : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;
        public float PlayerSpeed;
        public float ShootInterval;
        
        [Header("Fireball")]
        public Fireball FireballPrefab;
        public float FireballSpeed;
        
        [Header("Enemy")]
        public GameObject EnemyPrefab;
        public float EnemySpeed;
        public float EnemiesSpawnInterval;
        public float EnemiesSpawnRadius;
    }
}