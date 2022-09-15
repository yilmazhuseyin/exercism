using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor) => Generate(minFactor, maxFactor).Last().Pick();
    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor) => Generate(minFactor, maxFactor).First().Pick();
    private static IOrderedEnumerable<IGrouping<int, (int, int)>> Generate(int minFactor, int maxFactor) => Products(minFactor, maxFactor).GroupBy(g => g.Item1 * g.Item2).Check().OrderBy(g => g.Key);
    private static (int, IEnumerable<(int, int)>) Pick(this IGrouping<int, (int, int)> result) => (result.Key, result.Select(g => g));
    private static bool IsPalindrome(int number) => Digits(number).SequenceEqual(Digits(number).Reverse());
    private static IEnumerable<(int, int)> Products(int minFactor, int maxFactor) => from i in Range(minFactor, maxFactor) from j in Range(i, maxFactor) where IsPalindrome(i * j)select (i, j);
    private static IEnumerable<T> Check<T>(this IEnumerable<T> p)
    {
        if (p.Count() == 0) throw new ArgumentException();
        return p;
    }
    private static IEnumerable<int> Digits(int number)
    {
        while (number != 0)
        {
            yield return number % 10;
            number /= 10;
        }
    }
    private static IEnumerable<int> Range(int min, int max)
    {
        for (int i = min; i <= max; i++) yield return i;
    }
}
