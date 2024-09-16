using System;

public class Score : IStatistics
{
    private int _value;

    public Score(EnemyPool pool) => pool.Released += Increase;

    public event Action ValueChanged;
    
    public int Value => _value;

    public void Reset()
    {
        _value = 0;
        ValueChanged?.Invoke();
    }

    private void Increase()
    {
        _value++;
        ValueChanged?.Invoke();
    }
}
