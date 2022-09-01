using System;
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToUniversalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) => location switch
    {
        Location.NewYork => TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")),
        Location.London => TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time")),
        Location.Paris => TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(appointmentDateDescription), TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")),
        _ => throw new ArgumentOutOfRangeException()
    };

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
    {
        AlertLevel.Early => appointment.AddDays(-1),
        AlertLevel.Standard => appointment.AddMinutes(-105),
        AlertLevel.Late => appointment.AddMinutes(-30),
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        string zone = String.Empty;
        int daysBack = 7;
        
        switch (location)
        {
            case Location.NewYork: zone = "Eastern Standard Time"; break;
            case Location.London: zone = "Eastern Standard Time"; break;
            case Location.Paris: zone = "Eastern Standard Time"; break;
            default: break;
        }

        for (int i = 0; i < daysBack; i++) if (TimeZoneInfo.FindSystemTimeZoneById(zone).IsDaylightSavingTime(dt.AddDays(-i))) return true;
        
        return false;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        try
        {
            return location switch
            {
                Location.NewYork => DateTime.Parse(dtStr, CultureInfo.GetCultureInfo("en-US")),
                Location.London or Location.Paris => DateTime.Parse(dtStr, CultureInfo.GetCultureInfo("en-GB")),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        catch (FormatException)
        {
            return new DateTime(1, 1, 1, 0, 0, 0);
        }
    }
}
