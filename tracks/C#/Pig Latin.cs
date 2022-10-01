using System;
using System.Linq;
public static class PigLatin
{
    public static string Translate(string word)
    {
        if (!word.Contains(" ")) return Job(word);
        string[] allWords = word.Split(' ');
        string emptty = String.Empty;
        foreach (string w in allWords) emptty += Job(w) + " ";
        return emptty.Trim();
    }

    private static string Job(string word)
    {
        string[] first = { "a", "e", "i", "o", "u", "xr", "yt" };
        string[] seconnd = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
        string[] third = { "thr", "sch" };
        string[] fourth = { "ch", "th", "rh", "qu" };

        foreach (string item in first) if (word.IndexOf(item) == 0) return word + "ay";
        
        foreach (string item in third) if (word.IndexOf(item) == 0) return word = ToEnd(word, item) + "ay";
        
        foreach (string item in fourth) if (word.IndexOf(item) == 0) return word = ToEnd(word, item) + "ay";
        
        var firstL = word.Substring(0, 1);

        if (seconnd.Contains(firstL)) word = ToEnd(word, firstL);
        
        if (word.IndexOf("qu") == 0) word = ToEnd(word, "qu");
        
        return word + "ay";
    }
    private static string ToEnd(string word, string chars)
    {
        var count = word.IndexOf(chars);
        return word.Substring(count + chars.Length) + chars;
    }
}
