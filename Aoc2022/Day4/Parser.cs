namespace Aoc2022.Day4
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= File.ReadAllLines("Day4/input.txt");
        }


        public IEnumerable<Pair> Parse()
        {
            Load();

            var result = new List<Pair>();

            foreach (var line in input)
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
