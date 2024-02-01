using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Price { get; private set; } = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}