using System.Text;

namespace Aoc2022.Day01
{
    internal class CalorieCounting: IProblem
    {
        public string Name => "Calorie Counting";

        public int Day => 1;

        private List<Elf> elves;

        public CalorieCounting()
        {
            var input = File.ReadAllLines("Day01/input.txt");

            elves = new List<Elf>();
            var current = new Elf();

            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elves.Add(current);
                    current = new Elf();

                    continue;
                }

                current.Calories.Add(Convert.ToInt32(line));
            }
        }

        public string SolvePart1()
        {
            return elves
                .OrderByDescending(e => e.TotalCalories)
                .First()
                .TotalCalories
                .ToString();
        }

        public string SolvePart2()
        {
            return elves
                .OrderByDescending(e => e.TotalCalories)
                .Take(3)
                .Sum(e => e.TotalCalories)
                .ToString();
        }
    }
}
