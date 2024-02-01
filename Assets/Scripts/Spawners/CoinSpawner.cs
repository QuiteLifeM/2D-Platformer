using System.Collections;
using UnityEngine;

namespace Spawners
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] Point[] _points;
        [SerializeField] Coin _coin;

        private WaitForSeconds _waitForSeconds;
        private float _delay = 5f;

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
                Coin newCoin = Instantiate(_coin, point.transform.position, Quaternion.identity);

                yield return _waitForSeconds;
            }
        }
    }
}
