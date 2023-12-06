using System.Text;

namespace Aoc2022.Day05
{
    internal class SupplyStacks: IProblem
    {
        public string Name => "Supply Stacks";
        public int Day => 5;

        private readonly string[] input;
        private readonly List<Instruction> instructions = new();

        public SupplyStacks()
        {
            input = File.ReadAllLines("Day05/input.txt");

            var lines = input.SkipWhile(e => !string.IsNullOrWhiteSpace(e));

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var split = line.Split(' ');

                    var amount = Convert.ToInt32(split[1]);
                    var source = Convert.ToInt32(split[3]);
                    var destination = Convert.ToInt32(split[5]);

                    instructions.Add(new Instruction(amount, source, destination));
                }
            }
        }
        public string SolvePart1()
        {
            var stacks = BuildStacks();

            RearrangeSingle(stacks, instructions);

            return string.Join(string.Empty, stacks.Select(e => e.Value.Peek()));
        }

        public string SolvePart2()
        {
            var stacks = BuildStacks();

            RearrangeRanged(stacks, instructions);

            return string.Join(string.Empty, stacks.Select(e => e.Value.Peek()));
        }

        private void RearrangeSingle(IDictionary<int, Stack<char>> stacks, IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
                for (int i = 0; i < instruction.Amount; i++)
                    stacks[instruction.Destination].Push(stacks[instruction.Source].Pop());

        }

        private void RearrangeRanged(IDictionary<int, Stack<char>> stacks, IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                var crates = new List<char>();

                for (int i = 0; i < instruction.Amount; i++)
                    crates.Add(stacks[instruction.Source].Pop());

                crates.Reverse();

                foreach (var crate in crates)
                    stacks[instruction.Destination].Push(crate);
            }
        }

        private IDictionary<int, Stack<char>> BuildStacks()
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
    }
}
