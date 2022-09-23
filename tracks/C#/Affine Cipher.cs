using System;
public static class AffineCipher
{
    public static string Encode(string plainText, int a, int b)
    {
        if (a % 2 == 0 || a % 13 == 0) throw new ArgumentException();

        var result = String.Empty;

        foreach (var ch in plainText.ToLower().ToCharArray())
        {
            var en = Encode(ch, a, b);

            if (en != null) result += en;
        }

        for (var i = 0; i < result.Length / 5; i++)
        {
            var idx = 5 * (i + 1) + i;

            if (idx < result.Length) result = result.Insert(idx, " ");
        }
        return result;
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        if (a % 2 == 0 || a % 13 == 0) throw new ArgumentException();

        var mmi = GetMmi(a);

        var result = String.Empty;

        foreach (var ch in cipheredText.ToLower().ToCharArray())
        {
            var en = Decode(ch, mmi, b);
            if (en != null) result += en;
        }

        return result;
    }

    private static char? Encode(char ch, int a, int b)
    {
        if (char.IsDigit(ch)) return ch;
        
        if (!char.IsLetter(ch)) return null;
        
        var x = ((ch - 'a') * a + b) % 26;
        return (char)('a' + x);
    }
    private static char? Decode(char ch, int mmi, int b)
    {
        if (char.IsDigit(ch)) return ch;
        
        if (!char.IsLetter(ch)) return null;
        
        var x = (mmi * ((ch - 'a') - b)) % 26;

        if (x < 0) x += 26;
        
        return (char)('a' + x);
    }

    private static int GetMmi(int a)
    {
        for (var i = 1; i < 26; i++)
        {
            if (a * i % 26 == 1) return i;
        }
        throw new ArgumentException("I can't find a mmi");
    }
}
