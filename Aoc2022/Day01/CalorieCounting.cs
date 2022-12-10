using System.Text;

namespace Aoc2022.Day01
{
    internal static class CalorieCounting
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 1: Calorie Counting");
            builder.AppendLine();

            Parser parser = new Parser();

            var elves = parser
                .Parse()
                .OrderByDescending(e => e.TotalCalories)
                .ToList();

            builder.AppendLine("Find the Elf carrying the most Calories. How many total Calories is that Elf carrying?");
            builder.AppendLine($"{elves.First().TotalCalories}");
            builder.AppendLine();

            builder.AppendLine("Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?");
            builder.AppendLine($"{elves.Take(3).Sum(e => e.TotalCalories)}");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
