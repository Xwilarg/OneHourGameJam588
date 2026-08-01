using UnityEngine;

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
            if (!_isDead) _rb.linearVelocity = (Vector3.zero - transform.position).normalized * GameManager.Instance.Speed;
        }

        public void Die(Vector3 touchPoint)
        {
            if (_isDead) return;

            _rb.linearVelocity = (transform.position - touchPoint).normalized * 20f;
            Destroy(gameObject, 10f);
            _isDead = true;
        }
    }
}
