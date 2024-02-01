using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class HealthPotionSpawner : MonoBehaviour
    {
        [SerializeField] Point[] _points;
        [SerializeField] HealthPotion _healthPotion;

        private WaitForSeconds _waitForSeconds;
        private float _delay = 10f;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_delay);
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (enabled)
            {
                Point point = _points[Random.Range(0, _points.Length)];
                HealthPotion newHealthPotion = Instantiate(_healthPotion, point.transform.position, Quaternion.identity);

                yield return _waitForSeconds;
            }
        }
    }
}
