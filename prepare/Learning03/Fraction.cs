public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction(int numerator, int denominator) // Would make a good primary constructor
    {
        _numerator = numerator;
        _denominator = denominator;
    }
    
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }
    
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return _numerator / (double)_denominator;
    }
    
    
    public void SetNumerator(int newNumerator)
    {
        _numerator = newNumerator;
    }
    
    public void SetDenominator(int newDenominator)
    {
        _denominator = newDenominator;
    }
    
    public int GetNumerator()
    {
        return _numerator;
    }
    
    public int GetDenominator()
    {
        return _denominator;
    }
}