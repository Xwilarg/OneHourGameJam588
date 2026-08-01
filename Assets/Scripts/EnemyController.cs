using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourGameJam588
{
    public class EnemyController : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private bool _isDead = false;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_isDead)
            {
                _rb.linearVelocity = (Vector3.zero - transform.position).normalized * GameManager.Instance.Speed;
                if (Vector3.Distance(transform.position, Vector3.zero) < .1f)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }

        public void Die(Vector3 touchPoint)
        {
            if (_isDead) return;

            _rb.linearVelocity = (transform.position - touchPoint).normalized * 20f;
            Destroy(gameObject, 10f);
            _isDead = true;

            GameManager.KillCount++;
        }
    }
}
