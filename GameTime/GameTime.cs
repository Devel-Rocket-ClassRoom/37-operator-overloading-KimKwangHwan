using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

struct GameTime
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    public GameTime(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;

        while (Seconds >= 60)
        {
            Seconds -= 60;
            Minutes++;
        }
        while (Minutes >= 60)
        {
            Minutes -= 60;
            Hours++;
        }
    }

    public static GameTime operator +(GameTime a, GameTime b)
    {
        return new GameTime(a.Hours + b.Hours, a.Minutes + b.Minutes, a.Seconds + b.Seconds);
    }

    public static GameTime operator -(GameTime a, GameTime b)
    {
        int seconds = a.GetTotalSeconds() - b.GetTotalSeconds();
        int minutes = 0;
        int hours = 0;

        seconds = seconds < 0 ? 0 : seconds;
        
        return new GameTime(hours, minutes, seconds);
    }

    public static bool operator ==(GameTime a, GameTime b)
    {
        return a.GetTotalSeconds() == b.GetTotalSeconds();
    }

    public static bool operator !=(GameTime a, GameTime b)
    {
        return !(a == b);
    }

    public static bool operator <(GameTime a, GameTime b)
    {
        return a.GetTotalSeconds() < b.GetTotalSeconds();
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        return !(a < b);
    }

    public static GameTime operator *(GameTime a, int mul)
    {
        if (mul < 0)
        {
            throw new InvalidOperationException("음수는 사용할 수 없습니다.");
        }
        return new GameTime(0, 0, a.GetTotalSeconds() * mul);
    }

    public static GameTime operator *(int mul, GameTime a)
    {
        if (mul < 0)
        {
            throw new InvalidOperationException("음수는 사용할 수 없습니다.");
        }
        return new GameTime(0, 0, a.GetTotalSeconds() * mul);
    }

    public int GetTotalSeconds()
    {
        return Hours * 60 * 60 + Minutes * 60 + Seconds;
    }

    public override string ToString()
    {
        return $"{Hours}h {Minutes}m {Seconds}s";
    }

    public override bool Equals(object obj)
    {
        if (obj is GameTime gt)
        {
            return this == gt;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }
}