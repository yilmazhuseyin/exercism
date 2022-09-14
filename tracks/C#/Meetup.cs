using System;

public enum Schedule
{
  Teenth,First,Second,Third,Fourth,Last
}

public class Meetup
{
  private readonly int _month;
  private readonly int _year;

  public Meetup(int month, int year)
  {
        _month = month;
        _year = year;
  }

  public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
  {
      if (schedule == Schedule.Teenth) return Day(dayOfWeek, new DateTime(this._year, this._month, 13));
      
      else if (schedule == Schedule.Last) return Day(dayOfWeek, new DateTime(this._year, this._month, 1).AddMonths(1).AddDays(-7));
      
      else return Day(dayOfWeek, new DateTime(this._year, this._month, 1 + ((int)schedule - 1) * 7));
      
  }

  private DateTime Day(DayOfWeek dayOfWeek, DateTime baseDate)
  {
      
      var addDays = Day(dayOfWeek) - Day(baseDate.DayOfWeek);
     
      if (addDays < 0) addDays += 7;
      
      return baseDate.AddDays(addDays);
  }
  
  private int Day(DayOfWeek dayOfWeek) => ((int)dayOfWeek == 0 ? 7 : (int)dayOfWeek);
}
