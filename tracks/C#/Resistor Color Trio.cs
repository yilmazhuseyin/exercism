using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    public static string Label(string[] colors)
    {
        int result = 0;
        int i = 1;
        var temple = new Dictionary<string, int>
        {
            {"black", 0},
            {"brown", 1},
            {"red", 2},
            {"orange", 3},
            {"yellow", 4},
            {"green", 5},
            {"blue", 6},
            {"violet", 7},
            {"grey", 8},
            {"white", 9}
        };

        if (temple[colors[i + 1]] == 0) result = temple[colors[i - 1]] * 10 + temple[colors[i]];
        else result = (int)((temple[colors[i - 1]] * 10 + temple[colors[i]]) * Math.Pow(10, temple[colors[i + 1]]));
        if (result > 1000) return $"{result / 1000} kiloohms";
        return $"{result} ohms";
    }
}
