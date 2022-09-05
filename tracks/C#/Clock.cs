using System;

public struct Clock
{
    private readonly int _hours;
    public readonly int _minutes;

    public Clock(int hours, int minutes = 0)
    {
        _hours = (int)(((hours * 60 + minutes) / 60.0 % 24 + 24) % 24);
        _minutes = (int)((minutes % 60 + 60) % 60);
    }

    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);
    
    public override string ToString() => $"{_hours:00}:{_minutes:00}";
    
}
