using System;

class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;
    public int drivenDistance;
    public int batteryLevel;
    
    public RemoteControlCar(int speed, int batteryDrain){
        _speed = speed;
        _batteryDrain = batteryDrain;
        drivenDistance = 0;
        batteryLevel = 100;
    }        

    public bool BatteryDrained() => batteryLevel >= _batteryDrain ? false : true;

    public int DistanceDriven() => drivenDistance;

    public void Drive()
    {
        if(!BatteryDrained()) drivenDistance += _speed;
        batteryLevel -= _batteryDrain;
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50,4);
}

class RaceTrack
{
    private readonly double _distance;
    public RaceTrack(int distance){
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car){
        car.Drive();
        var driveCount = _distance / car.DistanceDriven();
        return driveCount * (100 - car.batteryLevel) <= 100 ? true : false; 
    } 
}
