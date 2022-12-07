namespace Aoc2022.Day3
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= File.ReadAllLines("Day3/input.txt");
        }

        public IEnumerable<Rucksack> Parse()
        {
            Load();

            List<Rucksack> result = new List<Rucksack>();

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(new Rucksack(line));

            return result;
        }
    }
}
