using System;

abstract class Activity
{
    private DateTime Date { get; set; }
    private int LengthInMinutes { get; set; }

    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({LengthInMinutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }

    protected int GetLengthInMinutes() => LengthInMinutes;
}
