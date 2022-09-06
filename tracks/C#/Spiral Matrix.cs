using System;
public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int x = 0;
        int y = 0;
        int m = 0; 
        int maxSize = size - 1;
        int[,] result = new int[size, size];

        for (var i = 1; i <= size * size; i++)
        {
            result[x, y] = i;

            if (x == m && y != maxSize) y++;
            else if (y == maxSize && x != maxSize) x++; 
            else if (x == maxSize && y != m) y--;
            else if (y == m && x != m + 1) x--; 
            else
            { 
              m++; 
              maxSize--; 
              y++;
            }
        }
        return result;
    }
}
