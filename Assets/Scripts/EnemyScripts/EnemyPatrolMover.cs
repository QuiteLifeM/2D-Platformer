using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPatrolMover : MonoBehaviour
{
    private const string IsRun = "IsRun";
    private const string IsAttack = "IsAttack";

    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _speed;

    private Animator _animator;
    private Queue<Transform> _targetsQueue;
    private Vector2 _targetPosition;
    private float _minDistance = 0.5f;
    private float _minDistanceToAttack = 2f;
    private SpriteRenderer _spriteRenderer;
    private EnemyTriggerZone _triggerZone;

    public bool IsAttacking { get; private set; }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _targetsQueue = new Queue<Transform>(_targets);
        _triggerZone = GetComponentInChildren<EnemyTriggerZone>();
        SetNextTarget();
    }

    private void Start()
    {
        GoPatrol();
    }

    private void Update()
    {
        DoActions();
    }

    private void DoActions()
    {
        if (_triggerZone.IsEntered == true)
        {
            _targetPosition = _triggerZone.PlayerPosition;
            transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

            if (transform.position.x > _targetPosition.x)
                _spriteRenderer.flipX = true;
            else
                _spriteRenderer.flipX = false;

            if (Vector2.Distance(transform.position, _targetPosition) < _minDistanceToAttack)
            {
                IsAttacking = true;
                _animator.SetBool(IsAttack, true);
            }
        }
        else
        {
            IsAttacking = false;
            _animator.SetBool(IsAttack, false);
            GoPatrol();
        }
    }

    private void GoPatrol()
    {
        if (transform.position.x > _targetPosition.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        if (Vector2.Distance(transform.position, _targetPosition) < _minDistance)
        {
            StopRun();
            SetNextTarget();
        }
        else
        {
            Run();
        }
    }

    private void SetNextTarget()
    {
        if (_targetsQueue.Any())
        {
            Transform target = _targetsQueue.Dequeue();
            _targetPosition = target.position;
            _targetsQueue.Enqueue(target);
        }
    }

    private void StopRun()
    {
        _animator.SetBool(IsRun, false);
    }

    private void Run()
    {
        _animator.SetBool(IsRun, true);
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
