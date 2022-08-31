using System;
using System.Collections.Generic;
using System.Linq;
public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        this.X = x;
        this.Y = y;
    }
    public ushort X { get; }
    public ushort Y { get; }
  
    public double Distance(Coord c) => Math.Pow((X - c.X), 2) + Math.Pow((Y - c.Y), 2);
}
public struct Plot
{
    private readonly Coord _c1;
    private readonly Coord _c2;
    private readonly Coord _c3;
    private readonly Coord _c4;
    public readonly double _longSq { get; }
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        _c1 = coord1;
        _c2 = coord2;
        _c3 = coord3;
        _c4 = coord4;
        _longSq = CalculateLongestSideSquared(coord1, coord2, coord3, coord4);
    }
    
    private static double CalculateLongestSideSquared(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        var _sides = new double[4];
        _sides[0] = c1.Distance(c2);
        _sides[1] = c2.Distance(c3);
        _sides[2] = c3.Distance(c4);
        _sides[3] = c4.Distance(c1);
        return _sides.Max();
    }
}
public class ClaimsHandler
{
    private List<Plot> _plots = new List<Plot>();
    public void StakeClaim(Plot plot)
    {
        if (!IsClaimStaked(plot)) _plots.Add(plot);
    }
    public bool IsClaimStaked(Plot plot) => _plots.Contains(plot);
    public bool IsLastClaim(Plot plot) => plot.Equals(_plots.Last());
    public Plot GetClaimWithLongestSide() => _plots.OrderByDescending(plot => plot._longSq).First();
}
