using System;
using System.Diagnostics.CodeAnalysis;

{
    Celsius temp = 36.5;
    double value = temp;
    Console.WriteLine(value);
}

{
    Celsius2 c = new Celsius2(100);
    Fahrenheit f = (Fahrenheit)c;

    Console.WriteLine(c);
    Console.WriteLine(f);
}

{
    Vector3 v1 = new Vector3(1, 2, 3);
    Vector3 v2 = new Vector3(4, 5, 6);

    Console.WriteLine(v1 + v2);
    Console.WriteLine(v1 - v2);
    Console.WriteLine(v1 * 2);
    Console.WriteLine(3 * v2);
    Console.WriteLine(-v1);
    Console.WriteLine(v1 == v2);
}

public struct Celsius
{
    public double Degrees;
    public Celsius(double degrees)
    {
        this.Degrees = degrees;
    }

    public static implicit operator double(Celsius c)
    {
        return c.Degrees;
    }

    public static implicit operator Celsius(double d)
    {
        return new Celsius(d);
    }
}

public struct Fahrenheit
{
    public double Degrees;

    public Fahrenheit(double degrees)
    {
        Degrees = degrees;
    }

    public override string ToString()
    {
        return $"{Degrees}°F";
    }
}

public struct Celsius2
{
    public double Degrees;
    public Celsius2(double degrees)
    {
        this.Degrees = degrees;
    }

    public static explicit operator Fahrenheit(Celsius2 c)
    {
        return new Fahrenheit(c.Degrees * 9 / 5 + 32);
    }

    public static explicit operator Celsius2(Fahrenheit f)
    {
        return new Celsius2((f.Degrees - 32) * 5 / 9);
    }

    public override string ToString()
    {
        return $"{Degrees}°C";
    }
}

public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector3 operator *(Vector3 v, float scalar)
    {
        return new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static Vector3 operator *(float scalar, Vector3 v)
    {
        return new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);
    }

    public static Vector3 operator -(Vector3 v)
    {
        return new Vector3(-v.X, -v.Y, -v.Z);
    }

    public static bool operator ==(Vector3 a, Vector3 b)
    {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(Vector3 a, Vector3 b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Vector3 other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public override string ToString()
    {
        return $"({X}., {Y}, {Z})";
    }
}