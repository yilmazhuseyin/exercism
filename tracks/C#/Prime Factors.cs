using System.Collections.Generic;
public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> results = new();
        int i;

        for (i = 2; number > 1; i++)
        {
            if (number % i == 0)
            {
                while (number % i == 0)
                {
                    results.Add(i);
                    number /= i;
                }
            }
        }
        return results.ToArray();
    }
}
