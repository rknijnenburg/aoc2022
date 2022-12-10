namespace Aoc2022.Day04
{
    internal class Pair
    {
        internal class Range
        {
            public int Start { get; }
            public int End { get; }

            public Range(int v1, int v2)
            {
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

        public Range First { get; }
        public Range Second { get; }

        public Pair(Range first, Range second)
        {
            First = first;
            Second = second;
        }

        public bool Covers()
        {
            return First.Covers(Second) || Second.Covers(First);

        }

        public bool Overlaps()
        {
            return First.Overlaps(Second) || Second.Overlaps(First);
        }
    }
}
