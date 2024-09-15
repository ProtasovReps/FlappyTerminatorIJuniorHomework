using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class Bullet : MonoBehaviour
{
    private int _damage;
    private Rigidbody2D _rigidbody;

    public abstract event Action<Bullet> WorkedOut;

    public int Damage => _damage;
    public Rigidbody2D Rigidbody => _rigidbody;

    public void Initialize(int damage) => _damage = damage;

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0f;
        GetComponent<Collider2D>().isTrigger = true;
    }
}