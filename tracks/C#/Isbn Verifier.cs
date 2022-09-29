using System;
public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        string realNumber = number.Trim().Replace("-", string.Empty);

        if (realNumber.Length != 10) return false;

        var result = 0;

        for (int i = 0; i < realNumber.Length; i++)
        {
            char c = realNumber[i];
            int num;

            if (char.IsDigit(c)) num = Convert.ToInt32(c - '0');
            else if (char.ToLower(c) == 'x' && i == 9) num = 10;
            else return false;
            
            result += num * (10 - i);
        }
        return result % 11 == 0;
    }
}
