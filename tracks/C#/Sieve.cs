using System;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 0) throw new ArgumentOutOfRangeException();

        var nonPrimes = new List<int>();
        var primes = new List<int>();

        for (int i = 2; i <= limit; i++)
        {
            var current = i;
            if (nonPrimes.Contains(current)) continue;
            primes.Add(current);

            do
            {
                nonPrimes.Add(current);
                current += i;
            } while (current <= limit);
        }
        return primes.ToArray();
    }
}
