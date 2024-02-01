using TMPro;
using UnityEngine;

public class HealthViewText : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _tmpText;

    private float MaxHealth => _health.MaxHealth;

    private void Awake()
    {
        _tmpText.text = $"{MaxHealth}/{MaxHealth}";
        _health.ValueChanged += UpdateHealth;
    }

    private void UpdateHealth(float targetValue)
    {
        _tmpText.text = $"{targetValue}/{MaxHealth}";
    }
}