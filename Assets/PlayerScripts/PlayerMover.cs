using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private float _negativeDirection = -1f;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoved;
    private bool _isJumped;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _isMoved = true;
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsMoved", _isMoved);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _isMoved = true;
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsMoved", _isMoved);
            transform.Translate(_speed * Time.deltaTime * _negativeDirection, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            _isMoved = false;
            _animator.SetBool("IsMoved", _isMoved);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumped = true;
            _animator.SetBool("IsJumped", _isJumped);
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJumped = false;
            _animator.SetBool("IsJumped", _isJumped);
        }
    }
}