using UnityEngine;

namespace SpaceWars
{
    public class PlayerShooting : ObjectPool
    {
        [Header("Shoot Settings")]
        [SerializeField] private LaserBullet _laserPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _fireDelay = 0.1f;

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
                    if (TryGetObject(out GameObject laserBullet))
                    {
                        _timePassedAfterShot = 0;

                        laserBullet.SetActive(true);
                        laserBullet.transform.position = _shootPoint.transform.position;
                    }
                }
            }

            DisableObjOutScreen();
        }
    }
}
