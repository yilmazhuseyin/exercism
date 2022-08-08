using System;
using System.Linq;

class BirdCount
{
    private readonly int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new int[] {0, 2, 5, 3, 7, 8, 4 };

    public int Today() => _birdsPerDay[_birdsPerDay.Length - 1];

    public void IncrementTodaysCount() => _birdsPerDay[_birdsPerDay.Length - 1]++;

    public bool HasDayWithoutBirds() => _birdsPerDay.Contains(0) ? true : false;

    public int CountForFirstDays(int numberOfDays)
    {
        int totalVisit = 0;
        for (int i = 0; i < numberOfDays; i++)
            totalVisit += _birdsPerDay[i];

        return totalVisit;
    }

    public int BusyDays()
    {
        int totalBusy = 0;
        for (int i = 0; i < _birdsPerDay.Length; i++){
            if(_birdsPerDay[i] >= 5)
                totalBusy++;
        }
            
        return totalBusy;
    }
}
