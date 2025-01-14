using System;

public record Clock
{
    private TimeOnly _time = new(0, 0);

    public Clock(int hours, int minutes)
    {
        _time = _time.AddHours(hours);
        _time = _time.AddMinutes(minutes);
    }

    public Clock Add(int minutesToAdd) => this with { _time = _time.AddMinutes(minutesToAdd) };

    public Clock Subtract(int minutesToSubtract) => this with { _time = _time.AddMinutes(-minutesToSubtract) };

    public override string ToString() => $"{_time.Hour:D2}:{_time.Minute:D2}";
}
