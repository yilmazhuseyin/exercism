using System;
using System.Collections.Generic;
using System.Linq;
public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}
public static class Sublist
{
    public static SublistType Classify<T>(List<T> listA, List<T> listB) where T : IComparable
    {
        bool isSuper(List<T> listOne, List<T> listTwo) => listOne.Count >= listTwo.Count && Enumerable.Range(0, listOne.Count - listTwo.Count + 1).Any(i1 => Enumerable.Range(0, listTwo.Count).All(i2 => listTwo[i2].CompareTo(listOne[i1 + i2]) == 0));
        return (isSuper(listA, listB), isSuper(listB, listA)) switch
        {
            (true, true) => SublistType.Equal,
            (true, false) => SublistType.Superlist,
            (false, true) => SublistType.Sublist,
            (false, false) => SublistType.Unequal,
        };
    }
}
