using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private readonly string _baseWord;

    public Anagram(string baseWord) => _baseWord = baseWord.ToLower();

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();

        if(potentialMatches.Where(x=>x.Length == _baseWord.Length).Count() < 1) return Array.Empty<string>();

        for (int i = 0; i < potentialMatches.Length; i++)
        {
            int count = 0;

            for (int k = 0; k < _baseWord.Length; k++)
            {
                if (_baseWord.Where(x => x == _baseWord[k]).Count() == potentialMatches[i].ToLower().Where(x => x == _baseWord[k]).Count()) count++;
            }

            if (count == _baseWord.Length && _baseWord != potentialMatches[i].ToLower()) result.Add(potentialMatches[i]);
        }

        return result.ToArray();
    }
}
