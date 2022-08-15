using System;
using System.Collections.Generic;
using System.Linq;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        List<char> result = ((identifier.Replace(" ", "_")).Replace("\0", "CTRL")).ToList();

        for (int i = 0; i < result.Count; i++)
        {
            if (result[i] == '-')
            {
                result.RemoveAt(i);
                result[i] = Convert.ToChar(result[i].ToString().ToUpper());
            }
        }

        result.RemoveAll(x => x != '_' ? !Char.IsLetter(x) || ((int)x >= 945 && (int)x <= 969) : false);
        return String.Join("", result);
    }
}
