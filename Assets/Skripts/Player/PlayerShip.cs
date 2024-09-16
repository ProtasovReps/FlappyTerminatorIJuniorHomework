using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private PlayerShooter _shooter;

    private Collider2D _collider;
    private PlayerHealth _health;
    private Vector2 _startPosition;

    public event Action Died;

    public IDamageable Health => _health;
    public IStatistics HealthStat => _health;

    public void Reset()
    {
        transform.position = _startPosition;
        _health.Revive();
    }

    private void OnEnable()
    {
        if (_health != null)
            _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public void Initialize(Gun gun, int maxHealthValue)
    {
        _health = new PlayerHealth(maxHealthValue);
        _collider = GetComponent<Collider2D>();
        _startPosition = transform.position;
        _health.Died += Die;

        _shooter.Initialize(gun);
    }
    private void Die() => Died?.Invoke();
}
