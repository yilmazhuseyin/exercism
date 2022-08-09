using System;

public static class ResistorColorDuo
{
    static string[] colorList = new string[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
    public static int Value(string[] colors)
    {
        string result = "";
        int count = 0;
        for (int i = 0; i < 2; i++)
            result += Array.IndexOf(colorList, colors[i]);

        return Convert.ToInt32(result);
    }
}
