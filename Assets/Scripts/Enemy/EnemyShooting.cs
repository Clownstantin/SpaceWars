using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _minTimeBetweenShots = 0.2f;
    [SerializeField] private float _maxTimeBetweenShots = 3f;

    private float _shootDelay;
    private Camera _camera;

    private void Start()
    {
        _shootDelay = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
        _camera = Camera.main;
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
    }
}
