using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerShipTracker))]
public abstract class Enemy : MonoBehaviour
{
    private EnemyHealth _health;
    private PlayerShipTracker _shipTracker;
    private IEnemyMoveable _movement;
    private IEnemyShootable _shooter;

    public event Action<Enemy> WorkedOut;

    public IDamageable Health => _health;

    private void OnEnable()
    {
        if (_shipTracker != null)
            _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public virtual void Initialize(int maxHealthValue, PlayerShip player, IEnemyMoveable moveable, IEnemyShootable shootable)
    {
        _shipTracker = GetComponent<PlayerShipTracker>();
        _movement = moveable;
        _shooter = shootable;
        _health = new EnemyHealth(maxHealthValue);

        _health.Died += Die;
        _shipTracker.Initialize(player);
        _shipTracker.StartTrack();
    }

    public void Revive(Vector2 targetPosition)
    {
        _health.Revive();
        _shooter.Shoot();
        _movement.Move(targetPosition);
        _shipTracker.StartTrack();
    }

    public void Die()
    {
        _shooter.StopShooting();
        _movement.StopMoving();
        _shipTracker.StopTrack();
        WorkedOut?.Invoke(this);
    }
}
