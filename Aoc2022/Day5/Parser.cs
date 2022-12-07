namespace Aoc2022.Day5
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= File.ReadAllLines("Day5/input.txt");
        }
        
        public IDictionary<int, Stack<char>> ParseStacks()
        {
            Load();

            var result = new Dictionary<int, Stack<char>>();

            Stack<char> GetStack(int number)
            {
                if (!result.ContainsKey(number))
                    result.Add(number, new Stack<char>());

                return result[number];
            }

            var lines = input
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
            Load();

            var result = new List<Instruction>();
            var lines = input.SkipWhile(e => !string.IsNullOrWhiteSpace(e));

            foreach (var line in lines)
                if (!string.IsNullOrWhiteSpace(line))
                    result.Add(new Instruction(line));

            return result;
        }


    }
}
