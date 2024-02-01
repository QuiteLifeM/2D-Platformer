using UnityEngine;

public class EnemyTriggerZone : MonoBehaviour
{
    public bool IsEntered { get; private set; }
    public Vector2 PlayerPosition { get; private set; }

    private void Awake()
    {
        IsEntered = false;
        PlayerPosition = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            IsEntered = true;
            PlayerPosition = player.transform.position;
            Debug.Log("Игрок вошёл в зону тригера");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEntered = false;
        Debug.Log("Игрок вышел из зоны тригера");
    }
}