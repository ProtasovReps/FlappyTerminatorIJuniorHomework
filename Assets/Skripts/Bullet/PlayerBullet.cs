using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public override event Action<Bullet> WorkedOut;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PoolReleaseZone>(out _))
        {
            WorkedOut?.Invoke(this);
        }

        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Health.TakeDamage(Damage);
            WorkedOut?.Invoke(this);
        }
    }
}
