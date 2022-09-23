using System;
using System.Collections.Generic;
using System.Linq;
public static class Transpose
{
    public static string String(string input)
    {
        var next = input.Split('\n');
        var maxLength = next.Max(x => x.Length);
        var list = new string[maxLength];

        for (var i = 0; i < next.Length; i++)
        {
            for (var j = 0; j < next[i].Length; j++) list[j] += next[i][j];
            var reMaxLenght = next.Skip(i).Max(x => x.Length);
            for (var k = next[i].Length; k < reMaxLenght; k++) list[k] += " ";
        }

        return string.Join("\n", list).TrimEnd();
    }
}
