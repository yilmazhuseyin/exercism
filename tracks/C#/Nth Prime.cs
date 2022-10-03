using System;
using System.Collections.Generic;
using System.Linq;
public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth == 0) throw new ArgumentOutOfRangeException();
        if (nth == 1) return 2;

        var result = 3;

        for (int i = 3, count = 2; count <= nth; i += 2)
        {
            if (isPrime(i))
            {
                result = i;
                count++;
            }
        }
        return result;
    }
    private static bool isPrime(int n)
    {
        if (n > 2 && n % 2 == 0) return false;
        var max = n / 2 + 1;
        for (var i = 3; i < max; i++) if (n % i == 0) return false;
        return true;
    }
}
