using System;

public static class BeerSong
    {
        public static string Recite(int startBottles, int takeDown)
        {
            var finalString = "";
            int count = 0;
            for (int i = startBottles; i >= 0; i--)
            {
                if (finalString != "") finalString += "\n\n";
                finalString += FixedString(i);
                count++;
                if (count >= takeDown) break;
            }
            return finalString;
        }

static string FixedString(int i)
    {
        if(i > 0)
        {
            var s = i != 1 ? "s" : "";
            var s2 = i == 2 ? "" : "s";
            var it = i == 1 ? "it" : "one";
            var no = i == 1 ? "no more" : $"{i - 1}";
            return $"{i} bottle{s} of beer on the wall, {i} bottle{s} of beer.\nTake {it} down and pass it around, {no} bottle{s2} of beer on the wall.";
        }else return $"No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.";
    }
}
