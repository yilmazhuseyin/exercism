using System;
using System.Text;
public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        StringBuilder sb = new StringBuilder();

        int i = 0;

        foreach (var c in plainValue)
        {
            if (i == 5)
            {
                sb.Append(' ');
                i = 0;
            }
            if (char.IsLetter(c) || char.IsDigit(c)) i++;
            if (char.IsLetter(c)) sb.Append(ToCipher(c));
            if (char.IsDigit(c)) sb.Append(c);
            
        }
        return sb.ToString().Trim();
    }
    public static string Decode(string encodedValue)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var c in encodedValue)
        {
            if (char.IsLetter(c)) sb.Append(ToCipher(c));
            
            if (char.IsDigit(c)) sb.Append(c);
            
        }
        return sb.ToString();
    }

    private static char ToCipher(char c)
    {
        int inputIndex = char.ToLower(c) - 'a';
        int backwardIndex = 25 - inputIndex;
        return Convert.ToChar('a' + backwardIndex);
    }
}
