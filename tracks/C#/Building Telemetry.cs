using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) => this.sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (latestSerialNum > serialNum)
        {
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = latestSerialNum;
            return false;
        }

        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        latestSerialNum = serialNum;
        return true;
    }
    public static RemoteControlCar Buy() => new RemoteControlCar();
    
}
public class TelemetryClient
{
    private readonly RemoteControlCar _car;
    public TelemetryClient(RemoteControlCar car)
    {
        _car = car;
    }
    public string GetBatteryUsagePerMeter(int serialNum)
    {
        int batteryPercentage;
        int distanceDrivenInMeters;

        _car.GetTelemetryData(ref serialNum, out batteryPercentage, out distanceDrivenInMeters);

        if (distanceDrivenInMeters == 0) return "no data";
        
        double usagePerMeter = (double)(100 - batteryPercentage) / (double)distanceDrivenInMeters;

        return $"usage-per-meter={usagePerMeter}";
    }
}
