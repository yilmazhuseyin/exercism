using System;
using System.Collections.Generic;
using System.Linq;
public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        return Enumerable.Range(0, input.Length).Select(x => string.Concat(Enumerable.Range(0, input[x].Length).Select(y => Count(x, y)))).ToArray();

        char Count(int i, int j)
        {
            if (input[i][j] == '*') return '*';

            int count = Follow(i - 1, j - 1) + Follow(i - 1, j + 0) + Follow(i - 1, j + 1) + Follow(i + 0, j - 1) + Follow(i + 0, j + 1) + Follow(i + 1, j - 1) + Follow(i + 1, j + 0) + Follow(i + 1, j + 1);

            if (count == 0) return ' ';
            return (char)('0' + count);
        }

        int Follow(int i, int j)
        {
            if (i < 0 || i >= input.Length) return 0;
            if (j < 0 || j >= input[i].Length) return 0;
            if (input[i][j] == '*') return 1;
            return 0;
        }
    }
}
