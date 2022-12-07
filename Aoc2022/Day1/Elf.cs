namespace Aoc2022.Day1
{
    internal class Elf
    {
        public List<int> Calories { get; } = new List<int>();

        public int TotalCalories => Calories.Sum();
    }
}
