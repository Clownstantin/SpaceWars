using UnityEngine;

namespace SpaceWars
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private Transform _transform;
        private float _minScreenPosY;

        private void Awake()
        {
            _transform = transform;
            _minScreenPosY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).y;
        }

        protected void Move(Vector2 direction) => _transform.Translate(direction * _speed * Time.deltaTime);

        protected void DestroyBulletOutScreen()
        {
            if (_transform.position.y <= _minScreenPosY)
                Destroy(gameObject);
        }
    }
}