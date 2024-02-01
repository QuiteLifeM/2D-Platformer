using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health _health;
    private EnemyPatrolMover _mover;

    public float AttackDamage { get; } = 15f;
    public bool IsAttack { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<EnemyPatrolMover>();
        IsAttack = _mover.IsAttacking;
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        IsAttack = _mover.IsAttacking;
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}