using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();

        int count = 0;

        while (number != 1)
        {
            if (number % 2 != 0) number = (number * 3) + 1;
            else number /= 2;

            count++;
        }

        return count;
    }
}
