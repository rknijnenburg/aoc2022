using System.Text;

namespace Aoc2022.Day08
{
    internal static class TreetopTreeHouse
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 8: Treetop Tree House");
            builder.AppendLine();

            var parser = new Parser();
            var trees = parser.Parse();

            builder.AppendLine("how many trees are visible from outside the grid?");
            builder.AppendLine($"{trees.SelectMany(e => e).Count(e => e.Visible)}");
            builder.AppendLine();

            builder.AppendLine("What is the highest scenic score possible for any tree?");
            builder.AppendLine($"{trees.SelectMany(e => e).Max(e => e.ScenicScore)}");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
