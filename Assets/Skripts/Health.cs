using System;

public class Health : IDamageable, IStatistics
{
    private int _maxHealthValue;
    private int _healthValue;
    
    public Health(int maxValue)
    {
        _maxHealthValue = maxValue;
        Revive();
    }

    public event Action Died;
    public event Action ValueChanged;

    public int Value => _healthValue;

    public void Revive() => _healthValue = _maxHealthValue;

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _healthValue -= damage;
        ValueChanged?.Invoke();

        if (_healthValue <= 0)
            Died?.Invoke();
    }
}
