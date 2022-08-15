using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input) => input.ToLower().Replace(" ", "").Distinct().ToList().RemoveAll(x => ((int)x >= 97 && (int)x <= 122)) == 26 ? true : false;
}
