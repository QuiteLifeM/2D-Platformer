using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 100;
    [SerializeField] private int _wallet;

    private int _attackDamage = 10;

    private PlayerMover _playerMover;

    public bool IsAttack { get; private set; }
    public int AttackDamage => _attackDamage;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        IsAttack = _playerMover.IsAttacking;
    }

    private void Update()
    {
        IsAttack = _playerMover.IsAttacking;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthPotion>(out HealthPotion healthPotion))
        {
            _healthPoint += healthPotion.HealthPointBonus;
            Debug.Log($"Здоровье пополнено на {healthPotion.HealthPointBonus}");
        }

        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet++;
        }

        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.IsAttack == true)
            {
                Debug.Log("игрок получил урон");
                _healthPoint -= enemy.AttackDamage;
            }
        }
    }
}
