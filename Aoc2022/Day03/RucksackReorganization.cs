using Aoc2022.Day02;
using System.Text;

namespace Aoc2022.Day03
{
    internal class RucksackReorganization: IProblem
    {
        public string Name => "Rucksack Reorganization";
        public int Day => 3;

        private readonly List<Rucksack> rucksacks = new();
        
        public RucksackReorganization()
        {
            var input = File.ReadAllLines("Day03/input.txt");

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    rucksacks.Add(new Rucksack(line));
        }
        private int CalculatePriority(ICollection<string> sources)
        {
            var c = FindCommonChar(sources);

            return ConvertPriority(c);
        }

        private int ConvertPriority(char c)
        {
            var v = c - 'A';

            if (v is >= 0 and < 26)
                return v + 27;

            return c - 'a' + 1;
        }

        private char FindCommonChar(ICollection<string> sources)
        {
            foreach (var c1 in sources.First())
            {
                bool f1 = true;

                foreach (var s in sources.Skip(1))
                {
                    bool f2 = false;

                    foreach (var c2 in s)
                    {
                        if (c1 == c2)
                        {
                            f2 = true;

                            break;
                        }
                    }

                    if (!f2)
                    {
                        f1 = false;

                        break;
                    }
                }

                if (f1)
                    return c1;
            }

            throw new NotImplementedException();
        }

        public string SolvePart1()
        {
            return rucksacks
                .Sum(e => CalculatePriority(e.Compartments))
                .ToString();
        }

        public string SolvePart2()
        {
            var groups = new List<IEnumerable<Rucksack>>();

            for (int i = 0; i < rucksacks.Count(); i += 3)
                groups.Add(rucksacks.Skip(i).Take(3).OrderBy(e => e.Contents.Length));

            return groups
                .Sum(e => CalculatePriority(e.Select(g => g.Contents).ToArray()))
                .ToString();
        }
    }
}

