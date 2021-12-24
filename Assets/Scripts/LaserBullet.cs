using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Transform _transform;

    private void Awake() => _transform = transform;

    private void Update() => _transform.Translate(Vector2.up * _speed * Time.deltaTime);
}
