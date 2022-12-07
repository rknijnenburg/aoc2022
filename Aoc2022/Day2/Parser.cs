namespace Aoc2022.Day2
{
    internal class Parser
    {
        private string[]? input;

        private void Load()
        {
            input ??= File.ReadAllLines("Day2/input.txt");
        }

        public IEnumerable<ResponseRound> ParseResponseRounds()
        {
            Load();

            var result = new List<ResponseRound>();
            
            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(ParseResponseRound(line));

            return result;
        }

        public IEnumerable<ResultRound> ParseResultRounds()
        {
            Load();

            var result = new List<ResultRound>();

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(ParseResultRound(line));

            return result;
        }

        private ResponseRound ParseResponseRound(string line)
        {
            return new ResponseRound(line[0], line[2]);
        }

        private ResultRound ParseResultRound(string line)
        {
            return new ResultRound(line[0], line[2]);
        }
    }
}
