using System;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var result = string.Empty;

        result += phrase[0]; 

        var index = 0; //To avoid repetitive additions

        for (int i = 0; i < phrase.Length; i++)
        {
            bool isLetter = char.IsLetter(phrase[i]);
            bool isapostrophe = phrase[i] == '\'';

            if (!isLetter && !isapostrophe && char.IsLetter(phrase[i + 1]) && index != i + 1)
            {
                result += phrase[i + 1];
                index = i + 1;

            }
            else if (!isLetter && !isapostrophe && char.IsLetter(phrase[i + 2]) && index != i + 1)
            {
                result += phrase[i + 2];
                index = i + 2;
            }
        }

        return result.ToUpper();
    }
}

//Seccond approach

using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        char[] separators = { ' ', '-', '_' };
        string abb = String.Join("", phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]));
        return abb.ToUpper();
    }
}
