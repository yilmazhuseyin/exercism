using System;

class RemoteControlCar
{
    int distance = 0;
    int battery = 100;
    
    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {distance} meters";
    }

    public string BatteryDisplay()
    {
        return battery > 0 ? $"Battery at {battery}%" : "Battery empty";
    }

    public void Drive()
    {
        battery--;
        if(battery > -1)
            distance += 20;
    }
}
