using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerAbilitySuck : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private Vector2 _triggerZoneSize;
    [SerializeField] private float _angle;

    private Health _health;
    private readonly int _duration = 6;
    private Collider2D _triggerZone;
    private Coroutine _coroutine;

    public bool IsTrigger { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        CheckTrigger();
    }

    public void Apply()
    {
        _coroutine = StartCoroutine(Suck());
    }

    private void Stop()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
    }

    private void CheckTrigger()
    {
        _triggerZone = Physics2D.OverlapBox(transform.position, _triggerZoneSize, _angle, _enemy);

        IsTrigger = _triggerZone != null;

        if (_triggerZone == null)
            Stop();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, _triggerZoneSize);
    }

    private IEnumerator Suck()
    {
        float endTime = Time.time + 6f;

        while (Time.time < endTime)
        {
            if (_triggerZone != null && _triggerZone.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage * Time.deltaTime);
                _health.Heal(_damage * Time.deltaTime);
                yield return null;
            }
        }
    }
}