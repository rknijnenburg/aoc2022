using System.Drawing;

namespace Aoc2022.Day04;

internal class Range
{
    public int Start { get; }
    public int End { get; }

    public Range(string slice)
    {
        var split = slice.Split("-");

        var v1 = Convert.ToInt32(split[0]);
        var v2 = Convert.ToInt32(split[1]);

        Start = Math.Min(v1, v2);
        End = Math.Max(v1, v2);
    }

    public bool Covers(Range range)
    {
        return range.Start >= Start && range.End <= End;
    }

    public bool Overlaps(Range range)
    {
        return (Start <= range.Start && range.Start <= End) || (Start <= range.End && range.End <= End);
    }
}