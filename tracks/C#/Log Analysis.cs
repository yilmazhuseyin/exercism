using System;
using System.Linq;

public static class LogAnalysis
{
    public static string SubstringAfter(this string source, string delimiter)
    {
        return source.Split(delimiter).Last();
    }

    public static string SubstringBetween(this string source, string delimiter1, string delimiter2)
    {
        return source.Split(delimiter1).Last().Split(delimiter2).First();
    }

    public static string Message(this string source)
    {
        return source.SubstringAfter(": ");
    }

    public static string LogLevel(this string source)
    {
        return source.Split(":").First().SubstringBetween("[", "]").Trim();
    }
}
