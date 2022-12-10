namespace Aoc2022.Day02
{
    internal class Parser
    {
        private string[]? input;

        private IEnumerable<string> Input => input ??= File.ReadAllLines("Day02/input.txt");

        public IEnumerable<ResponseRound> ParseResponseRounds()
        {
            var result = new List<ResponseRound>();
            
            foreach (var line in Input)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(ParseResponseRound(line));

            return result;
        }

        public IEnumerable<ResultRound> ParseResultRounds()
        {
            var result = new List<ResultRound>();

            foreach (var line in Input)
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
