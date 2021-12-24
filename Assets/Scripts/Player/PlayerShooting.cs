using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private LaserBullet _laserPrefab;
    [SerializeField] private Transform _shootPoint;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            var laser = Instantiate(_laserPrefab, _shootPoint.position, Quaternion.identity);
        }
    }
}
