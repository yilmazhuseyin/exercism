using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int sum = 0;
        foreach (var n in number.ToString()) sum += (int)Math.Pow(n - '0', number.ToString().Length);
        return sum == number;
    }
}
