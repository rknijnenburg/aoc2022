namespace Aoc2022.Day04
{
    internal class Pair
    {
        

        public Range First { get; }
        public Range Second { get; }

        public Pair(string line)
        {
            var slices = line.Split(',');
            
            First = new Range(slices[0]);
            Second = new Range(slices[1]);
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
