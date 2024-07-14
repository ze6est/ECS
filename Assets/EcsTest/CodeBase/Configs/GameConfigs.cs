using UnityEngine;

namespace EcsTest.CodeBase.Configs
{
    [CreateAssetMenu(menuName = "Configs", fileName = "Configs")]
    public class GameConfigs : ScriptableObject
    {
        [Header("Player")]
        public GameObject PlayerPrefab;
        public float PlayerSpeed;
        public float PlayerShootInterval;
        public int PlayerHealth;
        
        [Header("Fireball")]
        public Fireball FireballPrefab;
        public float FireballSpeed;
        
        [Header("Enemy")]
        public GameObject EnemyPrefab;
        public float EnemySpeed;
        public int EnemyDamage;
        public float EnemyAttackDistance;
        public float EnemyAttackInterval;
        public float EnemiesSpawnInterval;
        public float EnemiesSpawnRadius;
    }
}