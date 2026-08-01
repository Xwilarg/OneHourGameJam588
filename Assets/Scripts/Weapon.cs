using OneHourGameJam588;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    private Camera _cam;

    private Rigidbody2D _rb;
    private LineRenderer _lr;

    private void Awake()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
        _lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        var mousePos = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;

        // _rb.linearVelocity = (transform.position - mousePos).normalized * 10f;

        transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime * 10f);
        _lr.SetPositions(new Vector3[]
        {
            new Vector3(-0.51f, 2.08f, 0f),
            transform.position
        });

        var hits = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("Enemy"));
        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<EnemyController>(out var enn))
            {
                enn.Die(transform.position);
            }
        }
    }
}
