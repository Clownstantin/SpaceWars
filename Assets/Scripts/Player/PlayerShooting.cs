using UnityEngine;

namespace SpaceWars
{
    public class PlayerShooting : ObjectPool
    {
        [Header("Shoot Settings")]
        [SerializeField] private PlayerBullet _laserPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _fireDelay = 0.1f;
        [Header("SFX Settings")]
        [SerializeField] private AudioClip _shootSFX;
        [SerializeField] [Range(0, 1)] private float _shootVolume = 0.1f;

        private float _timePassedAfterShot = 0;

        private void Start()
        {
            Init(_laserPrefab.gameObject);
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                _timePassedAfterShot += Time.deltaTime;

                if (_timePassedAfterShot >= _fireDelay)
                {
                    _timePassedAfterShot = 0;

                    if (TryGetObject(out GameObject bullet))
                    {
                        bullet.transform.position = _shootPoint.position;
                        bullet.SetActive(true);

                        AudioSource.PlayClipAtPoint(_shootSFX, Camera.main.transform.position, _shootVolume);
                    }
                }
            }

            DisableObjOutScreen();
        }
    }
}
