using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        for (int i = 0; i < max; i++)
        {
            foreach (var number in multiples)
            {
                if (number != 0 && i % number == 0)
                {
                    sum += i;
                    break;
                }
            }
        }
        return sum;
    }
}
