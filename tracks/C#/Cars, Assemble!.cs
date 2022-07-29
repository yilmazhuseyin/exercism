using System;

static class AssemblyLine
{
    private static readonly int _rate = 221;
    
    public static double SuccessRate(int speed)
    {
        var s = speed;
        if(s == 0) return s;
        else if(s >= 1 && s <= 4) return 1;
        else if(s>=5 && s <=8) return 0.9;
        else if(s == 9) return 0.8;
        else return 0.77;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * _rate * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}
