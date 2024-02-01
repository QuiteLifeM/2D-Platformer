using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public event Action<float> ValueChanged;

    private float _currentValue;

    private void Awake()
    {
        _currentValue = MaxHealth;
    }

    private void Update()
    {
        if (_currentValue == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        _currentValue -= amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxHealth);
        ValueChanged?.Invoke(_currentValue);
    }

    public void Heal(float amount)
    {
        _currentValue += amount;
        _currentValue = Mathf.Clamp(_currentValue, 0, MaxHealth);
        ValueChanged?.Invoke(_currentValue);
    }
}