using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

struct GameCurrency
{
    public int Gold;
    public int Silver;

    public GameCurrency(int gold, int silver)
    {
        this.Gold = gold;
        this.Silver = silver;
        
        while (this.Silver >= 100)
        {
            this.Silver -= 100;
            this.Gold++;
        }
    }

    public static GameCurrency operator +(GameCurrency a, GameCurrency b)
    {
        return new GameCurrency(a.Gold + b.Gold, a.Silver + b.Silver);
    }

    public static GameCurrency operator -(GameCurrency a, GameCurrency b)
    {
        int silver = a.GetTotalSilver() - b.GetTotalSilver();
        int gold = 0;
        silver = silver < 0 ? 0 : silver;
        //while (silver >= 100)
        //{
        //    silver -= 100;
        //    gold++;
        //}
        return new GameCurrency(gold, silver);
    }

    public static bool operator ==(GameCurrency a, GameCurrency b)
    {
        return (a.Gold == b.Gold) && (a.Silver == b.Silver);
    }

    public static bool operator !=(GameCurrency a, GameCurrency b)
    {
        return !(a == b);
    }

    public static bool operator <(GameCurrency a, GameCurrency b)
    {
        return a.GetTotalSilver() < b.GetTotalSilver();
    }
    public static bool operator >(GameCurrency a, GameCurrency b)
    {
        return !(a < b);
    }

    public override string ToString()
    {
        return $"{Gold}G {Silver}S";
    }

    public int GetTotalSilver()
    {
        return Gold * 100 + Silver;
    }

    public override bool Equals(object obj)
    {
        if (obj is GameCurrency gc)
        {
            return this == gc;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Gold, Silver);
    }
}