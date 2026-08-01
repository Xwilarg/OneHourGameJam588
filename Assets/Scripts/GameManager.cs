using System.Collections;
using UnityEngine;

namespace OneHourGameJam588
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyPrefab;

        private float _spawnRate = 1f;

        public int KillCount { set; get; } = 0;

        private void Awake()
        {
            StartCoroutine(SpawnCoroutine());
        }

        public IEnumerator SpawnCoroutine()
        {
            var maxBounds = new Vector2(Screen.width, Screen.height);
            var maxPos = Camera.main.ScreenToWorldPoint(maxBounds);

            while (true)
            {
                Instantiate(_enemyPrefab, Random.onUnitCircle * maxPos.x, Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}
