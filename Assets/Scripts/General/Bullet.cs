using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    public event Action<Bullet> Released;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        Move();
    }

    public void Release()
    {
        Released?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Death();
        }
        if(collision.TryGetComponent(out Player player))
        {
            player.Death();
        }

        Released?.Invoke(this);
    }

    private void Move()
    {
        _rigidbody2D.velocity = _direction * _speed;
    }
}