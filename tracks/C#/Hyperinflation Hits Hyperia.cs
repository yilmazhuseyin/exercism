using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            return checked(@base * multiplier).ToString();
        }
        catch (OverflowException)
        {

            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        try
        {
            var result = checked(@base * multiplier);
            return result != float.PositiveInfinity ? result.ToString() : throw new OverflowException();
        }
        catch (OverflowException)
        {

            return "*** Too Big ***";
        }
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            return checked(salaryBase * multiplier).ToString();
        }
        catch (OverflowException)
        {

            return "*** Much Too Big ***";
        }
    }
}
