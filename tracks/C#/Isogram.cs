using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower().Replace(" ", "").Replace("-","");
        for (int i = 0; i < word.Length; i++)
        {
            for (int t = i+1; t < word.Length; t++)
            {
                if (word[i] == word[t])
                    return false;
            }
        }
        return true;
    }
}

