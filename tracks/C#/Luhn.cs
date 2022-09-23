using System;
public static class Luhn
{
    public static bool IsValid(string number)
    {
        int sum = 0;
        int count = 0;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (char.IsNumber(number[i]))
            {
                int num = (int)(number[i] - '0');

                if (count % 2 != 0)
                {
                    num *= 2;
                    num = num > 9 ? (num - 9) : num;
                }

                count++;
                sum += num;
            }
            else if (!char.IsWhiteSpace(number[i])) return false;
        }

        if (count < 2) return false;
        return sum % 10 == 0;
    }
}
