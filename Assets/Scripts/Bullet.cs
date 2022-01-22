using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Transform _transform;

    private void Awake() => _transform = transform;

    protected void Move(Vector2 direction) => _transform.Translate(direction * _speed * Time.deltaTime);
}
