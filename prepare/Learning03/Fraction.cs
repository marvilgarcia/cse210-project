using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor that initializes the fraction with a whole number (denominator defaults to 1)
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor that initializes the fraction with given numerator and denominator
    public Fraction(int top, int bottom)
    {
        _top = top;
        if (bottom != 0) // Check if bottom is not zero
            _bottom = bottom;
        else
            throw new ArgumentException("Denominator cannot be zero.");
    }

    // Getter and Setter for the top number
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for the bottom number
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0) // Ensure denominator is not zero
            _bottom = bottom;
        else
            throw new ArgumentException("Denominator cannot be zero.");
    }

    // Method to return the fraction in the form "top/bottom"
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
