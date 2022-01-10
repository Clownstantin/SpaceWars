using UnityEngine;

namespace SpaceWars
{
    [CreateAssetMenu(fileName = "new Wave", menuName = "Enemy Wave Config", order = 51)]
    public class WaveConfig : ScriptableObject
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _pathPrefab;
        [SerializeField] private float _timeBetweenSpawn = 0.5f;
        [SerializeField] private float _spawnRandomFactor = 0.3f;
        [SerializeField] private int _enemiesCount = 5;
        [SerializeField] private float _moveSpeed = 2f;

        public GameObject EnemyPrefab => _enemyPrefab;
        public float TimeBetweenSpawn => _timeBetweenSpawn;
        public float SpawnRandomFactor => _spawnRandomFactor;
        public int EnemiesCount => _enemiesCount;
        public float MoveSpeed => _moveSpeed;

        public Transform[] GetWaypointsArray()
        {
            Transform[] waveWaypoints = new Transform[_pathPrefab.transform.childCount];

            for (int i = 0; i < _pathPrefab.transform.childCount; i++)
                waveWaypoints[i] = _pathPrefab.transform.GetChild(i);

            return waveWaypoints;
        }
    }
}