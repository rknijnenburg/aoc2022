using System.Text;

namespace Aoc2022.Day03
{
    internal static class RucksackReorganization
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 3: Rucksack Reorganization");
            builder.AppendLine();

            Parser parser = new Parser();

            var rucksacks = parser
                .Parse()
                .ToList();

            builder.AppendLine("Find the item type that appears in both compartments of each rucksack. What is the sum of the priorities of those item types?");
            builder.AppendLine($"{rucksacks.Sum(e => CalculatePriority(e.Compartments))}");
            builder.AppendLine();

            var groups = new List<IEnumerable<Rucksack>>();
            
            for (int i = 0; i < rucksacks.Count(); i += 3)
                groups.Add(rucksacks.Skip(i).Take(3).OrderBy(e => e.Contents.Length));

            builder.AppendLine("Find the item type that corresponds to the badges of each three-Elf group. What is the sum of the priorities of those item types?");
            builder.AppendLine($"{groups.Sum(e => CalculatePriority(e.Select(g => g.Contents).ToArray()))}");
            builder.AppendLine();

            return builder.ToString();
        }


    private static int CalculatePriority(ICollection<string> sources)
        {
            var c = FindCommonChar(sources);

            return ConvertPriority(c);
        }

        private static int ConvertPriority(char c)
        {
            var v = c - 'A';

            if (v is >= 0 and < 26)
                return v + 27;

            return c - 'a' + 1;
        }

        private static char FindCommonChar(ICollection<string> sources)
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
    }
}

