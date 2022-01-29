using UnityEngine;

namespace SpaceWars
{
    public class EnemyShooting : MonoBehaviour
    {
        [Header("Shoot Settings")]
        [SerializeField] private EnemyBullet _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _minTimeBetweenShots = 0.2f;
        [SerializeField] private float _maxTimeBetweenShots = 2f;
        [Header("SFX Settings")]
        [SerializeField] private AudioClip _shootSFX;
        [SerializeField] [Range(0, 1)] private float _shootVolume = 0.1f;

        private float _shootDelay;

        private void Start()
        {
            _shootDelay = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
        }

        private void Update()
        {
            _shootDelay -= Time.deltaTime;

            if (_shootDelay <= 0)
            {
                Fire();
                _shootDelay = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
            }

        }

        private void Fire()
        {
            Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_shootSFX, Camera.main.transform.position, _shootVolume);
        }
    }
}