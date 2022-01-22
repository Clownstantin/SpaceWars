using UnityEngine;

public class EnemyBullet : Bullet
{
    private Camera _camera;

    private void Start() => _camera = Camera.main;

    private void Update()
    {
        Move(Vector2.down);
        DestroyBulletOutScreen();
    }

    private void DestroyBulletOutScreen()
    {
        Vector3 minScreenPos = _camera.ViewportToWorldPoint(new Vector3(0, 0));
        if (transform.position.y <= minScreenPos.y)
            Destroy(gameObject);
    }
}
