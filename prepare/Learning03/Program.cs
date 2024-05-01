using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new();
        Fraction frac2 = new(5);
        Fraction frac3 = new(3, 4);
        Fraction frac4 = new(1, 3);

        List<Fraction> myFractions = [frac1, frac2, frac3, frac4];
        // This is the same as List<Fraction> myFractions = new List<Fraction> {frac1, frac2, frac3, frac4};

        foreach (Fraction frac in myFractions)
        {
            Console.WriteLine(frac.GetFractionString());
            Console.WriteLine(frac.GetDecimalValue());
        }
    }
}