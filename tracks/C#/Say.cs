using System;
using System.Collections.Generic;
using System.Linq;

public static class Say
{
    private static string[] upToTwenty = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
    private static string[] upToHundred = { String.Empty, String.Empty, "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
    private static string[] bigNumbers = { "billion", "million", "thousand" };

    public static string InEnglish(long number)
    {
        string result = String.Empty;

        if (number < 0 || number >= Math.Pow(10, 12)) throw new ArgumentOutOfRangeException();

        if (number < 20) return upToTwenty[number];

        else if (number < 100)
        {
            result = upToHundred[number / 10];
            if (number % 10 != 0) result += "-" + upToTwenty[number % 10];
            return result;
        }
        else if (number < 1000)
        {
            result = upToTwenty[number / 100] + " hundred";
            if (number % 100 != 0) result += " " + InEnglish(number % 100);
            return result;
        }
        else
        {
            List<string> bigResult = new();

            long billion = (long)Math.Pow(10,9);

            for (var i = 0; i < 3; i++, number %= billion, billion /= 1000) bigResult.Add(InEnglish(number / billion) + " " + bigNumbers[i]);

            if (number != 0) bigResult.Add(InEnglish(number));

            return string.Join(' ', bigResult.Where(c => !c.StartsWith("zero")).ToArray());
        }
    }
}
