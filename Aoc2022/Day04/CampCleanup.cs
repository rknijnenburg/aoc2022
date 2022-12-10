using System.Text;

namespace Aoc2022.Day04
{
    internal static class CampCleanup
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 4: Camp Cleanup");
            builder.AppendLine();

            Parser parser = new Parser();

            var pairs = parser
                .Parse()
                .ToList();

            builder.AppendLine("In how many assignment pairs does one range fully contain the other?");
            builder.AppendLine($"{pairs.Count(e => e.Covers())}");
            builder.AppendLine();

            builder.AppendLine("In how many assignment pairs do the ranges overlap?");
            builder.AppendLine($"{pairs.Count(e => e.Overlaps())}");
            builder.AppendLine();
            
            return builder.ToString();
        }
    }
}
