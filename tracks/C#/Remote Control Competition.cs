using System;
using System.Collections.Generic;
using System.Linq;

public interface IRemoteControlCar
{
    public int DistanceTravelled { get; }
    public void Drive();
}
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }
    public void Drive() => DistanceTravelled += 10;
    public int CompareTo(ProductionRemoteControlCar second) => this.NumberOfVictories.CompareTo(second.NumberOfVictories);
}
public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public void Drive() => DistanceTravelled += 20;
}
public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();
    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar car1,
        ProductionRemoteControlCar car2) => new[] { car1, car2 }.OrderBy(c => c).ToList();
}
