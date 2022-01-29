using UnityEngine;

namespace SpaceWars
{
    public class PlayerShooting : MonoBehaviour
    {
        [Header("Shoot Settings")]
        [SerializeField] private PlayerBullet _laserPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _fireDelay = 0.1f;
        [Header("SFX Settings")]
        [SerializeField] private AudioClip _shootSFX;
        [SerializeField] [Range(0, 1)] private float _shootVolume = 0.1f;

        private float _timePassedAfterShot = 0;

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

                    AudioSource.PlayClipAtPoint(_shootSFX, Camera.main.transform.position, _shootVolume);
                    Instantiate(_laserPrefab, _shootPoint.position, Quaternion.identity);
                }
            }
        }
    }
}
