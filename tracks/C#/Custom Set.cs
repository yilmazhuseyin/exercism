using System;
using System.Collections.Generic;
using System.Linq;
public class CustomSet
{
    private List<int> list;
    public CustomSet(params int[] values)
    {
        list = new();
        list.AddRange(values);
    }

    public CustomSet Add(int value)
    {
        if (list.IndexOf(value) == -1) list.Add(value);
        return this;
    }
    
    public bool Empty() => list.Count == 0;

    public bool Contains(int value) => list.Contains(value);

    public bool Subset(CustomSet right) => list.All(x => right.Contains(x));

    public bool Disjoint(CustomSet right) => !list.Any(x => right.Contains(x));

    public CustomSet Intersection(CustomSet right) => new(list.Where(x => right.Contains(x)).ToArray());

    public CustomSet Difference(CustomSet right) => new(list.Where(x => !right.Contains(x)).ToArray());

    public CustomSet Union(CustomSet right)
    {
        CustomSet union = new(list.ToArray());
        foreach (var item in right.list) union.Add(item);
        return union;
    }

    public override bool Equals(object? obj) => obj is not null && obj.GetType() == GetType() && ((CustomSet)obj).Subset(this) && Subset((CustomSet)obj);
}
