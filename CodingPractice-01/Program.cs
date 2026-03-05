using System;
using System.Diagnostics.CodeAnalysis;

{
    Counter c = new Counter(5);
    Console.WriteLine(-c);
    c++;
    Console.WriteLine(c);
}

{
    Fraction f1 = new Fraction(1, 2);
    Fraction f2 = new Fraction(1, 3);

    Console.WriteLine(f1 + f2);
    Console.WriteLine(f1 * f2);
}

{
    Money m1 = new Money(1000, "KRW");
    Money m2 = new Money(2000, "KRW");
    Console.WriteLine(m1 == m2);
    Console.WriteLine(m1 < m2);
}

{
    Vector2 v = new Vector2(1, 2);
    v += new Vector2(3, 4);

    Console.WriteLine(v);
}

public struct Counter
{
    public int Value;

    public Counter(int value)
    {
        Value = value;
    }

    public static Counter operator -(Counter c)
    {
        return new Counter(-c.Value);
    }

    public static Counter operator ++(Counter c)
    {
        return new Counter(c.Value++);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}

public struct Fraction
{
    public int Numerator;
    public int Denominator;

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;

        return new Fraction(num, den);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public struct Money
{
    public decimal Amount;
    public string Currency;

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static bool operator ==(Money a, Money b)
    {
        return a.Currency == b.Currency && a.Amount == b.Amount;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }

    public static bool operator <(Money a, Money b)
    {
        if (a.Currency !=  b.Currency)
        {
            throw new InvalidOperationException("통화가 다릅니다.");
        }
        return a.Amount < b.Amount;
    }
    public static bool operator >(Money a, Money b)
    {
        return (a < b);
    }
    public override bool Equals(object obj)
    {
        if (obj is Money other)
        {
            return this == other;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}

public struct Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x; Y = y;
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}