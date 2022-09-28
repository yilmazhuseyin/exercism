using System;
using System.Collections.Generic;
using System.Linq;
public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var result = new List<uint>();
        foreach (var number in numbers)
        {
            var index = result.Count;
            result.Add(number & 0x7Fu);

            var left = number >> 7;
            while (left != 0)
            {
                var currentbits = left & 0x7Fu;
                result.Insert(index, currentbits | 0x80u);
                left = left >> 7;
            }
        }
        return result.ToArray();
    }
    public static uint[] Decode(uint[] bytes)
    {
        if ((bytes.Last() & 0x80u) == 0x80u) throw new InvalidOperationException();
        var result = new List<uint>();
        var current = 0u;
        foreach (var nbyte in bytes)
        {
            if ((nbyte & 0x80u) == 0x80u)
            {
                var obyte = nbyte ^ 0x80u;
                current = (current << 7) | obyte;
            }
            else
            {
                current = (current << 7) | nbyte;
                result.Add(current);
                current = 0u;
            }
        }
        return result.ToArray();
    }
}
