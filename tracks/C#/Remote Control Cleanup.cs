public class RemoteControlCar
{
    private Speed _currentSpeed;
    public CarTelemetry Telemetry { get; }

    public RemoteControlCar() => Telemetry = new CarTelemetry(this);

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    public string CurrentSponsor { get; private set; }

    public string GetSpeed() => _currentSpeed.ToString();
    
    private void SetSponsor(string sponsorName) => CurrentSponsor = sponsorName;
    
    private void SetSpeed(Speed speed) => _currentSpeed = speed;
    
    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }
        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }
        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond) unitsString = "centimeters per second";
            return Amount + " " + unitsString;
        }
    }

    public class CarTelemetry
    {
        RemoteControlCar _car;
        public CarTelemetry(RemoteControlCar car) => _car = car;
        
        public void Calibrate()
        {
        }
        public bool SelfTest() => true;
        
        public void ShowSponsor(string sponsorName) => _car.SetSponsor(sponsorName);
        
        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps") speedUnits = SpeedUnits.CentimetersPerSecond;
            _car.SetSpeed(new Speed(amount, speedUnits));
        }

    }
}
