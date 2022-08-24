using System;

public static class ResistorColorDuo
{
    static string[] colorList = new string[] {"black", "brown","red","orange","yellow","green","blue","violet","grey","white"};
    public static int Value(string[] colors)
    {
        string result = "";
        int count = 0;
        foreach (var item in colors){
            if(count < 2){
                result += Array.IndexOf(colorList, item);
                count++;
            }
        }
        return Convert.ToInt32(result);
    }
}
