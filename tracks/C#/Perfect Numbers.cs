using System;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException();

        int count = Enumerable.Range(1, number - 1).Where(x => number % x == 0).Sum();

        if (count == number) return Classification.Perfect;
        else if (count > number) return Classification.Abundant;
        else return Classification.Deficient;
    }
}

