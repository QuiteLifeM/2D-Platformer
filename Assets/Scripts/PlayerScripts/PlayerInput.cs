using UnityEngine;

[RequireComponent(typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAbilitySuck))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _playerMover;
    private PlayerAnimation _playerAnimation;
    private PlayerAttacker _playerAttacker;
    private PlayerAbilitySuck _playerAbilitySuck;
    private float _direction = 0f;
    private bool _isLeft = false;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerAttacker = GetComponent<PlayerAttacker>();
        _playerAbilitySuck = GetComponent<PlayerAbilitySuck>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (_playerAbilitySuck.IsTrigger)
                _playerAbilitySuck.Apply();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _playerAttacker.Attack(_isLeft);
            _playerAnimation.Attack();
        }

        if (Input.GetKeyUp(KeyCode.H))
        {
            _playerAnimation.UnAttack();
        }

        if (Input.GetKey(KeyCode.D))
        {
            _direction = 1f;
            _isLeft = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _direction = -1f;
            _isLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            _direction = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerMover.Jump();
            _playerAnimation.SetJump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _playerAnimation.UnSetJump();
        }

        _playerAnimation.PlayMovement(_direction, _isLeft);
        _playerMover.GetDirection(_direction);
    }
}