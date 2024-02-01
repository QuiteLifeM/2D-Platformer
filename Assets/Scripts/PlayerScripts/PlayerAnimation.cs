using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsMoved = "IsMoved";
    private const string IsJumped = "IsJumped";
    private const string IsAttack = "IsAttack";

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _isMoved;
    private bool _isJumped;
    private bool _isAttack;
    private float _direction;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayMovement(float direction, bool isRight)
    {
        Flip(isRight);
        
        if (direction != 0)
        {
            _isMoved = true;
            _animator.SetBool(IsMoved, _isMoved);
        }
        else
        {
            _isMoved = false;
            _animator.SetBool(IsMoved, _isMoved);
        }
    }

    public void SetJump()
    {
        _isJumped = true;
        _animator.SetBool(IsJumped, _isJumped);
    }

    public void UnSetJump()
    {
        _isJumped = false;
        _animator.SetBool(IsJumped, _isJumped);
    }

    public void Attack()
    {
        _isAttack = true;
        _animator.SetBool(IsAttack, _isAttack);
    }

    public void UnAttack()
    {
        _isAttack = false;
        _animator.SetBool(IsAttack, _isAttack);
    }

    private void Flip(bool isRight)
    {
        _spriteRenderer.flipX = isRight;
    }
}