using System;
using System.Linq;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        var units = new List<string>() { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        var tenth = new List<string>() { "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        var hundreds = new List<string>() { "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        var thousand = new List<string>() { "M", "MM", "MMM", "MMMM" };

        var values = value.ToString().Reverse().ToArray();
        var result = new List<string>();

        for (var i = 0; i < values.Length; i++)
        {
            var index = (int)char.GetNumericValue(values[i]);
            var minusIndex = index - 1;

            if (index != 0)
            {
                switch (i)
                {
                    case 0: result.Add(units[minusIndex]); break;
                    case 1: result.Add(tenth[minusIndex]); break;
                    case 2: result.Add(hundreds[minusIndex]); break;
                    case 3: result.Add(thousand[minusIndex]); break;
                }
            }
        }
        result.Reverse();
        return String.Join("", result);
    }
}
