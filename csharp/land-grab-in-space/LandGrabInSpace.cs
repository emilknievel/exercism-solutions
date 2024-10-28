using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord(ushort x, ushort y)
{
    private ushort X { get; } = x;
    private ushort Y { get; } = y;

    public bool Equals(Coord other) => X == other.X && Y == other.Y;

    public override bool Equals(object obj) => obj is Coord other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public double DistanceTo(Coord other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
}

public struct Plot(Coord c1, Coord c2, Coord c3, Coord c4)
{
    private Coord C1 { get; } = c1;
    private Coord C2 { get; } = c2;
    private Coord C3 { get; } = c3;
    private Coord C4 { get; } = c4;

    public bool Equals(Plot other) =>
        C1.Equals(other.C1) && C2.Equals(other.C2) && C3.Equals(other.C3) && C4.Equals(other.C4);

    public override bool Equals(object obj) => obj is Plot other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(C1, C2, C3, C4);

    public double MaxDistance()
    {
        var distances = new double[4];

        distances[0] = C1.DistanceTo(C2);
        distances[1] = C2.DistanceTo(C3);
        distances[2] = C3.DistanceTo(C4);
        distances[3] = C4.DistanceTo(C1);

        return distances.Max();
    }
}

public class ClaimsHandler
{
    private readonly List<Plot> _plots = [];

    public void StakeClaim(Plot plot) => _plots.Add(plot);

    public bool IsClaimStaked(Plot plot) => _plots.Contains(plot);

    public bool IsLastClaim(Plot plot) => _plots[^1].Equals(plot);

    public Plot GetClaimWithLongestSide() => _plots.OrderByDescending(p => p.MaxDistance()).First();
}
