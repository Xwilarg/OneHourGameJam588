using System.Collections;
using UnityEngine;

namespace OneHourGameJam588
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameObject _enemyPrefab;

        private float _spawnRate = 1f;

        public int KillCount { set; get; } = 0;
        public float Speed { set; get; } = 5f;

        private void Awake()
        {
            Instance = this;
            StartCoroutine(SpawnCoroutine());
        }

        public IEnumerator SpawnCoroutine()
        {
            var maxBounds = new Vector2(Screen.width, Screen.height);
            var maxPos = Camera.main.ScreenToWorldPoint(maxBounds);

            while (true)
            {
                Instantiate(_enemyPrefab, Random.onUnitCircle * maxPos.x, Quaternion.identity);

                KillCount++;
                if (KillCount % 10 == 0 && _spawnRate > .4f)
                {
                    _spawnRate -= .2f;
                    Speed += .5f;
                }

                yield return new WaitForSeconds(_spawnRate);
            }
        }
    }
}
