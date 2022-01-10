using System.Collections.Generic;
using UnityEngine;

namespace SpaceWars
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private WaveConfig[] _waveConfigs;

        private WaveConfig _currentWave;
        private int _waveIndex = 0;
        private int _spawnedEnemyCount = 0;
        private float _spawnDelay = 0;

        private void Start()
        {
            _currentWave = _waveConfigs[_waveIndex];
        }

        private void Update()
        {
            SpawnAllEnemiesInWave(_currentWave);
        }

        private void SpawnAllEnemiesInWave(WaveConfig wave)
        {
            if (_spawnedEnemyCount < wave.EnemiesCount)
            {
                _spawnDelay += Time.deltaTime;

                if (_spawnDelay >= wave.TimeBetweenSpawn)
                {
                    _spawnDelay = 0;
                    var enemy = Instantiate(wave.EnemyPrefab, wave.GetWaypointsArray()[0].position, Quaternion.identity);

                    if (enemy.TryGetComponent(out EnemyPathing enemyPathing))
                        enemyPathing.SetWaveConfig(wave);

                    _spawnedEnemyCount++;
                }
            }
            else SwitchWave();
        }

        private void SwitchWave()
        {
            _waveIndex++;

            if (_waveIndex < _waveConfigs.Length)
            {
                _spawnedEnemyCount = 0;
                _currentWave = _waveConfigs[_waveIndex];
            }
            else _waveIndex = -1;
        }
    }
}
