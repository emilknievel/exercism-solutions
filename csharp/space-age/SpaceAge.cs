using System.Collections.Generic;

public class SpaceAge(int seconds)
{
    private readonly Dictionary<string, double> _orbitalPeriods = new()
    {
        { "Mercury", 0.2408467 },
        { "Venus", 0.61519726 },
        { "Mars", 1.8808158 },
        { "Jupiter", 11.862615 },
        { "Saturn", 29.447498 },
        { "Uranus", 84.016846 },
        { "Neptune", 164.79132 },
    };

    public double OnEarth() => seconds / 31_557_600.0;

    public double OnMercury() => OnEarth() / _orbitalPeriods["Mercury"];

    public double OnVenus() => OnEarth() / _orbitalPeriods["Venus"];

    public double OnMars() => OnEarth() / _orbitalPeriods["Mars"];

    public double OnJupiter() => OnEarth() / _orbitalPeriods["Jupiter"];

    public double OnSaturn() => OnEarth() / _orbitalPeriods["Saturn"];

    public double OnUranus() => OnEarth() / _orbitalPeriods["Uranus"];

    public double OnNeptune() => OnEarth() / _orbitalPeriods["Neptune"];
}