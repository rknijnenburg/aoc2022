namespace Aoc2022.Day04
{
    internal class Parser
    {
        private string[]? input = null;
        private IEnumerable<string> Input => input ??= File.ReadAllLines("Day04/input.txt");

        public IEnumerable<Pair> Parse()
        {
            var result = new List<Pair>();

            foreach (var line in Input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(ParsePair(line));

            return result;
        }

        private Pair ParsePair(string line)
        {
            var slices = line.Split(',');
            
            return new Pair(ParseRange(slices[0]), ParseRange(slices[1]));
    }

        private Pair.Range ParseRange(string slice)
        {
            var split = slice.Split("-");

            var v1 = Convert.ToInt32(split[0]);
            var v2 = Convert.ToInt32(split[1]);

            return new Pair.Range(v1, v2);
        }
    }
}
