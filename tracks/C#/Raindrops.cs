using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        string result = String.Empty;
        if(number % 3 == 0) result += "Pling";
        if(number % 5 == 0) result += "Plang";
        if(number % 7 == 0) result += "Plong";
        return result.Length < 5 ? number.ToString() : result;
        
    }
}
