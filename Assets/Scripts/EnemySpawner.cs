using System.Collections;
using UnityEngine;

namespace SpaceWars
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private WaveConfig[] _waveConfigs;
        [SerializeField] private bool _isLooping = false;

        private IEnumerator Start()
        {
            do yield return StartCoroutine(SpawnAllWaves());
            while (_isLooping);
        }

        private IEnumerator SpawnAllWaves()
        {
            for (int i = 0; i < _waveConfigs.Length; i++)
            {
                WaveConfig currentWave = _waveConfigs[i];
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
        }

        private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
        {
            var spawnDelay = new WaitForSeconds(wave.TimeBetweenSpawn);

            for (int i = 0; i < wave.EnemiesCount; i++)
            {
                var enemy = Instantiate(wave.EnemyPrefab, wave.GetWaypointsArray()[0].position, Quaternion.identity);

                if (enemy.TryGetComponent(out EnemyPathing enemyPathing))
                    enemyPathing.SetWaveConfig(wave);

                yield return spawnDelay;
            }
        }
    }
}
