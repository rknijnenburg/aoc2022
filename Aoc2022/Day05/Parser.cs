using Aoc2022.Day15;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Aoc2022.Day05
{
    internal class Parser
    {
        private readonly string[] input;

        public Parser()
        {
            input = File.ReadAllLines("Day05/input.txt");
        }
        
        
        public IDictionary<int, Stack<char>> ParseStacks()
        {
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
            var result = new List<Instruction>();
            var lines = input.SkipWhile(e => !string.IsNullOrWhiteSpace(e));

            foreach (var line in lines)
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var split = line.Split(' ');

                    var amount = Convert.ToInt32(split[1]);
                    var source = Convert.ToInt32(split[3]);
                    var destination = Convert.ToInt32(split[5]);

                    result.Add(new Instruction(amount, source, destination));
                }
                    

            return result;
        }


    }
}
