using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class OcrNumbers
{
    private static char GetNumber(byte value) => value switch {
        0b1101111 => '0',
        0b1001 => '1',
        0b1011110 => '2',
        0b1011011 => '3',
        0b111001 => '4',
        0b1110011 => '5',
        0b1110111 => '6',
        0b1001001 => '7',
        0b1111111 => '8',
        0b1111011 => '9',
        _ => '?'
    };
   
    private static bool IsMultiple(this int dividend, int divisor) => dividend % divisor == 0;

    public static string Convert(string input)
    {
        var lines = input.Split('\n');

        if (!lines.Length.IsMultiple(4)) throw new ArgumentException();

        var chars = new List<byte>();
        var result = new StringBuilder();
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            if (!line.Length.IsMultiple(3)) throw new ArgumentException();
            if (i != 0 && ((i + 1).IsMultiple(4)))
            {
                result.Append(String.Concat(chars.Select((x, index) => GetNumber(x))));
                continue;
            }
            var nmbrIndex = 0;
            var firstLineofNumbers = false;
            if (i.IsMultiple(4))
            {
                firstLineofNumbers = true;
                if (i != 0)
                {
                    result.Append(',');
                    chars.Clear();
                }
            }
            for (int j = 0; j < line.Length; j++)
            {
                if (j != 0 && j.IsMultiple(3)) nmbrIndex++;
                if (firstLineofNumbers)
                {
                    var isValidPosition = j == 1 || (j - 1).IsMultiple(3);
                    if (isValidPosition) chars.Add((byte)(line[j] == '_' ? 1 : 0));
                    continue;
                }
                if (line[j] != ' ')
                    if ((nmbrIndex.IsMultiple(2) == j.IsMultiple(2) && line[j] != '|') || (nmbrIndex.IsMultiple(2) ^ j.IsMultiple(2) && line[j] != '_'))
                        chars[nmbrIndex] = byte.MaxValue;
                if (chars[nmbrIndex] == byte.MaxValue) continue;
                chars[nmbrIndex] = (byte)((chars[nmbrIndex] << 1) + (line[j] != ' ' ? 1 : 0));
            }
        }
        return result.ToString();
    }
}
