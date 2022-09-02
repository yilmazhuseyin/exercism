using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        int index;
        string result = String.Empty;
        string a = "abcdefghijklmnopqrstuvwxyz";

        foreach (char letter in text)
        {
            index = (Array.IndexOf(a.ToCharArray(), char.ToLower(letter)) + shiftKey) % 26;

            if (!Char.IsLetter(letter))
            {
                result += letter;
                continue;
            }else if (char.IsUpper(letter)) result += a.ToUpper()[index];
            else result += a[index];
        }
        return result;
    }
}
