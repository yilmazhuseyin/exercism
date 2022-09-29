using System;
using System.Collections.Generic;
using System.Linq;
public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var result = new Dictionary<char, int>();

        foreach (var item in texts)
        {
            foreach (var letter in item)
            {
                if (char.IsLetter(letter))
                {
                    char lowerLetter = char.ToLower(letter);

                    if (!result.ContainsKey(lowerLetter)) result[lowerLetter] = 0;
                    
                    result[lowerLetter]++;
                }
            }
        }

        return result;
    }
}
