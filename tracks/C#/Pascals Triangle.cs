using System;
using System.Collections.Generic;
using System.Linq;
public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows) => Enumerable.Range(1, rows).Select(x => Enumerable.Range(0, x).SelectMany(a => new int[] { Calculate(x - 1, a) }).ToArray());
    private static int Calculate(int row, int pos)
    {
        int result = 1;

        for (int i = pos + 1; i <= row; i++) result *= i;
        
        for (int i = 1; i < (row - pos + 1); i++) result /= i;
        
        return result;
    }
}
