using System;

class Program
{
    static void Main(string[] args)

    {
        // Create fractions using different constructors
        Fraction fraction1 = new Fraction();         // 1/1
        Fraction fraction2 = new Fraction(5);        // 5/1
        Fraction fraction3 = new Fraction(6, 7);     // 6/7

        // Display fractions using GetFractionString method
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction3.GetFractionString());

        // Change values using setters
        fraction1.SetTop(3);
        fraction1.SetBottom(4);

        // Display fractions after changes
        Console.WriteLine(fraction1.GetFractionString());
        
        // Display decimal values using GetDecimalValue method
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetDecimalValue());

        Console.ReadLine(); // To keep console window open
    }
}

