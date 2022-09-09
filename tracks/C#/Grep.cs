using System;
using System.IO;
using System.Collections.Generic;
public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var flagList = flags.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        HashSet<string> flagSet = new HashSet<string>(flagList);

        bool inverse = flagSet.Contains("-v");
        bool entire = flagSet.Contains("-x");
        bool plural = files.Length > 1;
        bool lineNumber = flagSet.Contains("-n");
        bool fileName = flagSet.Contains("-l");
        bool caseInsensitive = flagSet.Contains("-i");

        string result = string.Empty;
        string comparePattern;
        string compareLine;

        foreach (string file in files)
        {
            string[] lines = File.ReadAllLines(file);

            int count = 1;

            bool same = false;

            foreach (string line in lines)
            {
                comparePattern = (caseInsensitive) ? pattern.ToLower() : pattern;

                compareLine = (caseInsensitive) ? line.ToLower() : line;

                if (entire) same = compareLine == comparePattern;
                else same = compareLine.Contains(comparePattern);

                same = (inverse) ? !same : same;

                if (same && fileName)
                {
                    result += ((result != "") ? "\n" : "") + file;
                    break;
                }
                
                if (!fileName)
                {
                    if (same)
                    {
                        result += ((result != "") ? "\n" : "") + ((plural) ? $"{file}:" : "") +((lineNumber) ? $"{count}:" : "");
                        result += line;
                    }
                }
                count++;
            }
        }
        return result;
    }
}
