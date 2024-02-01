using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private float _direction;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    public void GetDirection(float direction)
    {
        _direction = direction;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, 0, 0);
    }
}