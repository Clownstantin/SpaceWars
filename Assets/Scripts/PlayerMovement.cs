using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private Vector2 _maxBounds = new Vector2(4f, 7.5f);
    [SerializeField] private Vector2 _minBounds = new Vector2(-4f, -7.5f);

    private Transform _transform;

    private readonly string _horizontalAxis = "Horizontal";
    private readonly string _verticalAxis = "Vertical";

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalMove = Input.GetAxis(_horizontalAxis) * _moveSpeed * Time.deltaTime;
        var verticalMove = Input.GetAxis(_verticalAxis) * _moveSpeed * Time.deltaTime;

        var newXPosClamped = Mathf.Clamp(_transform.position.x + horizontalMove, _minBounds.x, _maxBounds.x);
        var newYPosClamped = Mathf.Clamp(_transform.position.y + verticalMove, _minBounds.y, _maxBounds.y);

        _transform.position = new Vector2(newXPosClamped, newYPosClamped);
    }
}
