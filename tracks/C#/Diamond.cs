using System;
using System.Linq;
public static class Diamond
{
    public static string Make(char target)
    {
        var left = Enumerable.Range(0, (2 * (target - 'A') + 1) / 2 + 1).Select(i => ((char)('A' + i)).ToString().PadLeft((target - 'A') - i + 1).PadRight((2 * (target - 'A') + 1) / 2 + 1));
        var half = left.Select(l => string.Concat(l.Concat(l.Take((2 * (target - 'A') + 1) / 2).Reverse())));
        return string.Join("\n", half.Concat(half.Take((2 * (target - 'A') + 1) / 2).Reverse()));
    }
}
