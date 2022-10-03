using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public static class CryptoSquare
{
    private static string NormalizedPlaintext(string plaintext)
    {
        var charList = plaintext.ToLower().Where(char.IsLetterOrDigit).ToArray();
        return String.Join("", charList);
    }
    private static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        var result = new List<string>();
        var sum = plaintext.Length;
        var count = (int)Math.Ceiling(Math.Sqrt(sum));
        for (var i = 0; i < sum; i += count) result.Add((i + count) < sum ? plaintext.Substring(i, count) : plaintext.Substring(i));
        return result;
    }
    private static string Encoded(string plaintext)
    {
        var normalized = NormalizedPlaintext(plaintext);
        var segments = PlaintextSegments(normalized).ToList();
        var encoded = new StringBuilder();
        for (var i = 0; i < segments.First().Length; i++)
        {
            foreach (var segment in segments)
            {
                encoded.Append(i < segment.Length ? segment[i] : ' ');
            }
            if (i < segments.First().Length - 1)
            {
                encoded.Append(' ');
            }
        }
        return encoded.ToString();
    }
    public static string Ciphertext(string plaintext)
    {
        return plaintext == string.Empty
            ? string.Empty
            : Encoded(plaintext);
    }
}
