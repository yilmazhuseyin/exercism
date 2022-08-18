using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> newDict = new Dictionary<string, int>();

        foreach (int key in old.Keys)
        {
            foreach (string letter in old[key])
            {
                newDict.Add(letter.ToLower(), key);
            }
        }
        return newDict;
    }
}
