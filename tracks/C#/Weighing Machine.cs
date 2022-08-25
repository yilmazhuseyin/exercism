using System;

class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        this.Precision = precision;
    }

    public double Precision { get; set; }

    private double _weight;

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            else _weight = value;
        }
    }

    public string DisplayWeight
    {
        get => $"{(this.Weight - this.TareAdjustment).ToString("F3")} kg";
    }
    public double TareAdjustment { get; set; } = 5;
}
