using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private Health _health;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerMover = GetComponent<PlayerMover>();
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthPotion>(out HealthPotion healthPotion))
        {
            _health.Heal(healthPotion.HealthPointBonus);
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.Refill(coin.Price);
        }

        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsAttack == true)
            {
                _health.TakeDamage(enemy.AttackDamage);
            }
        }
    }
}