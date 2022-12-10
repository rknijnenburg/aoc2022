namespace Aoc2022.Day05
{
    internal class Parser
    {
        private string[]? input = null;

        private IEnumerable<string> Input => input ??= File.ReadAllLines("Day05/input.txt");
        
        public IDictionary<int, Stack<char>> ParseStacks()
        {
            var result = new Dictionary<int, Stack<char>>();

            Stack<char> GetStack(int number)
            {
                if (!result.ContainsKey(number))
                    result.Add(number, new Stack<char>());

                return result[number];
            }

            var lines = Input
                .TakeWhile(e => !string.IsNullOrEmpty(e))
                .Reverse()
                .Skip(1);

            foreach (var line in lines)
            {
                var i = 1;

                for (int s = 0; s < line.Length; s += 4)
                {
                    var entry = line.Substring(s, 3);

                    if (!string.IsNullOrWhiteSpace(entry))
                        GetStack(i).Push(entry[1]);

                    i++;
                }
            }

            return result;
        }

        public IEnumerable<Instruction> ParseInstructions()
        {
            var result = new List<Instruction>();
            var lines = Input.SkipWhile(e => !string.IsNullOrWhiteSpace(e));

            foreach (var line in lines)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(new Instruction(line));

            return result;
        }


    }
}
