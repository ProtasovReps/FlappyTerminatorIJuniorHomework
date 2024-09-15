using System;

public interface IStatistics
{
    public event Action ValueChanged;

    public int Value { get; }
}
