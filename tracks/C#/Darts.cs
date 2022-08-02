using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
         double pos = Math.Pow(x,2) + Math.Pow(y,2);
         switch (pos)
        {
            case <= 1:
                return 10;
            case <= 25:
                return 5;
            case <= 100:
                return 1;
            default:
                return 0;
        }
    }
}
