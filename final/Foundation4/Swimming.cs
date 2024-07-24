using System;

class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthInMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }
}
