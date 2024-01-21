using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _healthPoint = 100;
    private int _attackDamage = 15;
    private EnemyPatrolMover _mover;

    public int AttackDamage => _attackDamage;
    public bool IsAttack { get; private set; }

    private void Awake()
    {
         _mover = GetComponent<EnemyPatrolMover>();
        IsAttack = _mover.IsAttacking;
    }

    private void Update()
    {
        IsAttack = _mover.IsAttacking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            if (player.IsAttack == true)
            {
                Debug.Log("Враг получил урон");
                _healthPoint -= player.AttackDamage;
            }
        }
    }
}
