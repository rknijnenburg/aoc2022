namespace Aoc2022.Day01
{
    internal class Parser
    {
        private string[]? input;
        private IEnumerable<string> Input => input ??= File.ReadAllLines("Day01/input.txt");

        public IEnumerable<Elf> Parse()
        {
            var result = new List<Elf>();
            var current = new Elf();

            foreach (var line in Input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    result.Add(current);
                    current = new Elf();

                    continue;
                }

                current.Calories.Add(Convert.ToInt32(line));
            }

            return result;
        }
    }
}
