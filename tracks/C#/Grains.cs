using System;
using System.Linq;


public static class Grains
{
    public static double Square(int n) => n <= 0 || n > 64 ? throw new ArgumentOutOfRangeException(nameof(n)) : Math.Pow(2, n - 1);

    public static double Total() => Enumerable.Range(1, 64).Sum(Square);
}
