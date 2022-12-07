namespace Aoc2022.Day1
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= File.ReadAllLines("Day1/input.txt");
        }

        public IEnumerable<Elf> Parse()
        {
            Load();

            var result = new List<Elf>();
            var current = new Elf();

            foreach (var line in input)
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
