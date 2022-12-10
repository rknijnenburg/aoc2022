namespace Aoc2022.Day03
{
    internal class Parser
    {
        private string[]? input = null;

        private  IEnumerable<string> Input => input ??= File.ReadAllLines("Day03/input.txt");
        
        public IEnumerable<Rucksack> Parse()
        {
            List<Rucksack> result = new List<Rucksack>();

            foreach (var line in Input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(new Rucksack(line));

            return result;
        }
    }
}
