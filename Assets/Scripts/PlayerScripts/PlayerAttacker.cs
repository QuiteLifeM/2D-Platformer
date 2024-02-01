using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _distance;

    public void Attack(bool isLeft)
    {
        Vector2 direction;

        if (isLeft == true)
        {
            direction = new Vector2(-1, 0);
        }
        else
        {
            direction = new Vector2(1, 0);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _distance, _enemy);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
        }
    }   
}