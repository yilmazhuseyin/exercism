using System;
using System.Collections.Generic;
using System.Linq;
public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        return phrase.Split(" ,\n\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).GroupBy(word => (String.Concat(word.Where(x => char.IsLetterOrDigit(x) || x == '\'')).Trim('\'')).ToLower()).ToDictionary(dic => dic.Key, grp => grp.Count());
    }
}
