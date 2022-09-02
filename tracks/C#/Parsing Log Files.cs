using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");
    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^*=-]+>");
    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, @""".*password.*""", RegexOptions.IgnoreCase).Count;
    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", string.Empty);
    public string[] ListLinesWithPasswords(string[] lines)
    {
        var pLines = new List<string>();

        foreach (var item in lines)
        {
            Match passwordMatch = Regex.Match(item, @"password\w+", RegexOptions.IgnoreCase);
            if (passwordMatch == Match.Empty) pLines.Add($"--------: {item}");
            else pLines.Add($"{passwordMatch.Value}: {item}");
        }

        return pLines.ToArray();
    }
}
