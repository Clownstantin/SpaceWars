using UnityEngine;

namespace SpaceWars
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private Transform _transform;
        private float _minScreenPosY;
        private float _maxScreenPosY;


        private void Awake()
        {
            _transform = transform;
            _minScreenPosY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y;
            _maxScreenPosY = Camera.main.ViewportToWorldPoint(new Vector3(1, 1)).y;
        }

        protected void Move(Vector2 direction) => _transform.Translate(direction * _speed * Time.deltaTime);

        protected void DestroyBulletOutScreen(Bullet bullet)
        {
            if (bullet is EnemyBullet)
            {
                if (_transform.position.y <= _minScreenPosY)
                    Destroy(gameObject);
            }
            else
            {
                if (_transform.position.y >= _maxScreenPosY)
                    Destroy(gameObject);
            }
        }
    }
}