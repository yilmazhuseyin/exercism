using System;
using System.Collections;
public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input) => Flatten(input, new ArrayList());
    private static IEnumerable Flatten(IEnumerable input, IList list)
    {
        foreach (var item in input)
        {
            if (item is null) continue;
            
            if (item is IEnumerable) Flatten(item as IEnumerable, list);
            
            else list.Add(item);
            
        }

        return list;
    }
}
