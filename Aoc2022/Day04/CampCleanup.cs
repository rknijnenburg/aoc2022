using System.Text;

namespace Aoc2022.Day04
{
    internal class CampCleanup: IProblem
    {
        public string Name => "Camp Cleanup";
        public int Day => 4;

        private readonly List<Pair> pairs = new();
        
        public CampCleanup()
        {
            var input = File.ReadAllLines("Day04/input.txt");

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    pairs.Add(new Pair(line));
        }
        public string SolvePart1()
        {
            return pairs
                .Count(e => e.Covers())
                .ToString();
        }

        public string SolvePart2()
        {
            return pairs
                .Count(e => e.Overlaps())
                .ToString();
        }
    }
}
