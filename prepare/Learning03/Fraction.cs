using System;
using System.Runtime.CompilerServices;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;

    }

    public Fraction (int wholenumber)
    {
        _top = wholenumber;
        _bottom = 1;
    }

    public Fraction (int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
      return $"{_top}/{_bottom}";

    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }


}