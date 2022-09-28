using System;
using System.Collections.Generic;
public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var count = 0;
        foreach (var x in input) count++;
        return count;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        input.Reverse();
        return input;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var result = new List<TOut>();
        foreach (var x in input) result.Add(map(x));
        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var x in input) if (predicate(x)) result.Add(x);
        return result;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        foreach (var x in input) start = func(start, x); 
        return start;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        input.Reverse();
        foreach (var x in input) start = func(x, start);
        return start;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var result = new List<T>();
        foreach (var x in input) foreach (var y in x) result.Add(y);
        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        foreach (var x in right) left.Add(x);
        return left;
    }
}
