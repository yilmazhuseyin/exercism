using System;
using System.Diagnostics;
public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r) => r.Expreal(realNumber);
}
public struct RationalNumber
{
    private readonly int _n;
    private readonly int _d;
    public RationalNumber(int numerator, int denominator)
    {
        var GreatestCommonDivisor = GreatestCommenDivisor(numerator, denominator);
        _n = numerator / GreatestCommonDivisor;
        _d = denominator / GreatestCommonDivisor;
    }

    private static int GreatestCommenDivisor(int numerator, int denominator) => denominator == 0 ? numerator : GreatestCommenDivisor(denominator, numerator % denominator);

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var lowestCommonDenominator = r1._d == r2._d ? r1._d : r1._d * r2._d;
        return new RationalNumber(r1._n * (lowestCommonDenominator / r1._d) + r2._n * (lowestCommonDenominator / r2._d), lowestCommonDenominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var lowestCommonDenominator = r1._d == r2._d ? r1._d : r1._d * r2._d;
        return new RationalNumber(r1._n * (lowestCommonDenominator / r1._d) - r2._n * (lowestCommonDenominator / r2._d), lowestCommonDenominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1._n * r2._n, r1._d * r2._d);

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2) => new RationalNumber(r1._n * r2._d, r1._d * r2._n);

    public RationalNumber Abs() => new RationalNumber(Math.Abs(_n), Math.Abs(_d));

    public RationalNumber Reduce() => new RationalNumber(_n, _d);

    public RationalNumber Exprational(int power) => new RationalNumber((int)Math.Pow(_n, power), (int)Math.Pow(_d, power));

    public double Expreal(int baseNumber) => Math.Pow(baseNumber, _n / (double)_d);
}
