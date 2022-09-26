using System;
using System.Collections.Generic;
using System.Linq;
public static class ScaleGenerator
{
    private static readonly string[] scaleSharps = new[] { "A", "A#", "B", "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#" };
    private static readonly string[] scaleFlats = new[] { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
    private static readonly string[] tonicUsingSharps = new[] { "C", "F#", "G", "D", "A", "E", "B", "a", "e", "b", "f#", "c#", "g#", "d#" };

    public static string[] Chromatic(string tonic)
    {
        if (tonicUsingSharps.Contains(tonic))
        {
            tonic = tonic.ToUpper();
            return Enumerable.Concat(scaleSharps.SkipWhile(x => String.Compare(tonic, x, true) != 0), scaleSharps.TakeWhile(x => String.Compare(tonic, x, true) != 0)).ToArray();
        }
        else
        {
            tonic = tonic.ToUpper();
            return Enumerable.Concat(scaleFlats.SkipWhile(x => String.Compare(tonic, x, true) != 0), scaleFlats.TakeWhile(x => String.Compare(tonic, x, true) != 0)).ToArray();
        }
    }
    public static string[] Interval(string tonic, string pattern)
    {
        var result = new List<string>();
        string[] tonics = Chromatic(tonic);
        int i = 0;
        foreach (var item in pattern)
        {
            result.Add(tonics[i]);
            int s = item == 'm' ? 1 : item == 'M' ? 2 : item == 'A' ? 3 : 0;
            i = i + s;
        }
        return result.ToArray();
    }
}
