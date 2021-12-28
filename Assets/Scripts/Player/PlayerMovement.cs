using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _boundOffset = 0.5f;

    private Transform _transform;
    private Camera _camera;
    private Vector2 _maxXY;
    private Vector2 _minXY;

    private readonly string _horizontalAxis = "Horizontal";
    private readonly string _verticalAxis = "Vertical";

    private void Start()
    {
        _transform = transform;

        SetUpMoveBoundaries();
    }


    private void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries()
    {
        _camera = Camera.main;

        Vector3 boundsOffset = new Vector3(_boundOffset, _boundOffset);

        _minXY = _camera.ViewportToWorldPoint(new Vector3(0, 0)) + boundsOffset;
        _maxXY = _camera.ViewportToWorldPoint(new Vector3(1, 1)) - boundsOffset;
    }

    private void Move()
    {
        Vector3 move = _transform.position;

        move.x += Input.GetAxis(_horizontalAxis) * _moveSpeed * Time.deltaTime;
        move.y += Input.GetAxis(_verticalAxis) * _moveSpeed * Time.deltaTime;

        move.x = Mathf.Clamp(move.x, _minXY.x, _maxXY.x);
        move.y = Mathf.Clamp(move.y, _minXY.y, _maxXY.y);

        _transform.position = move;
    }
}
