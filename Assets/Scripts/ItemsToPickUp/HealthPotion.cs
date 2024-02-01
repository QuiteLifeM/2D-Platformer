using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float HealthPointBonus {  get; private set; }

    private void Start()
    {
        HealthPointBonus = 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
