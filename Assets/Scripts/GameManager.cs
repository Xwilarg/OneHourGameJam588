using System.Collections;
using UnityEngine;

namespace OneHourGameJam588
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { private set; get; }

        [SerializeField]
        private GameObject _enemyPrefab;

        [SerializeField]
        private SpriteRenderer _sr;
        [SerializeField]
        private Sprite[] _sprites;

        private float _spawnRate = 1f;

        public int SpawnCount { set; get; } = 0;
        public static int KillCount = 0;
        public float Speed { set; get; } = 5f;

        private void Awake()
        {
            KillCount = 0;
            Instance = this;
            StartCoroutine(SpawnCoroutine());
        }

        public void UpdateSprite()
        {
            _sr.sprite = _sprites[Mathf.Clamp(Mathf.FloorToInt(KillCount / 10), 0, _sprites.Length - 1)];
        }

        public IEnumerator SpawnCoroutine()
        {
            var maxBounds = new Vector2(Screen.width, Screen.height);
            var maxPos = Camera.main.ScreenToWorldPoint(maxBounds);

            while (true)
            {
                Instantiate(_enemyPrefab, Random.onUnitCircle * maxPos.x, Quaternion.identity);

                SpawnCount++;
                if (SpawnCount % 10 == 0 && _spawnRate > .4f)
                {
                    _spawnRate -= .2f;
                    Speed += .5f;
                }

                UpdateSprite();

                yield return new WaitForSeconds(_spawnRate);
            }
        }
    }
}
