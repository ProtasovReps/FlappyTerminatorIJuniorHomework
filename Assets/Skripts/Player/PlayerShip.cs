using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] private PlayerShooter _shooter;
    [SerializeField] private ColliderSwitcher _colliderSwitcher;

    private Collider2D _collider;
    private PlayerHealth _health;

    public IDamageable Health => _health;
    public IStatistics HealthStat => _health;

    public void OnEnable()
    {
        if (_health != null)
            _health.Died += Die;
    }

    public void OnDisable() => _health.Died -= Die;

    public void Initialize(Gun gun, int maxHealthValue)
    {
        _health = new PlayerHealth(maxHealthValue);
        _collider = GetComponent<Collider2D>();

        _health.Died += Die;
        _shooter.Initialize(gun);
        _colliderSwitcher.Initialize(_health, _collider);
    }

    private void Die()
    {
        Time.timeScale = 0f;
    }
}
