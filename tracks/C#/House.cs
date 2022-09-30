using System;
using System.Collections.Generic;
using System;
public static class House
{
    
    public static string Recite(int verseNumber)
    {
        var result = "This is the " + part[verseNumber].Split("\n")[0];

        for (var i = verseNumber - 1; i > 0; i--)
        {
            var secondPart = part[i].Split("\n")[1];
            result = result + $" that {secondPart}";
        }

        return result;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string result = String.Empty;

        for (int i = startVerse; i <= endVerse; i++)
        {
            if (i == endVerse) result = result + Recite(i);
            else result = result + Recite(i) + "\n";
        }

        return result;
    }

    private static readonly Dictionary<int, string> part = new Dictionary<int, string>
    {
        {1,"house that Jack built.\nlay in the house that Jack built."},
        {2,"malt\nate the malt"},
        {3,"rat\nkilled the rat"},
        {4,"cat\nworried the cat"},
        {5,"dog\ntossed the dog"},
        {6,"cow with the crumpled horn\nmilked the cow with the crumpled horn"},
        {7,"maiden all forlorn\nkissed the maiden all forlorn"},
        {8,"man all tattered and torn\nmarried the man all tattered and torn"},
        {9,"priest all shaven and shorn\nwoke the priest all shaven and shorn"},
        {10,"rooster that crowed in the morn\nkept the rooster that crowed in the morn"},
        {11,"farmer sowing his corn\nbelonged to the farmer sowing his corn"},
        {12,"horse and the hound and the horn"}
    };
}
