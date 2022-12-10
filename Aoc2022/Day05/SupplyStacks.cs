using System.Text;

namespace Aoc2022.Day05
{
    internal static class SupplyStacks
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 5: Supply Stacks");
            builder.AppendLine();

            var parser = new Parser();
            var instructions = parser.ParseInstructions();

            var stacks = parser.ParseStacks();
            
            RearrangeSingle(stacks, instructions);

            builder.AppendLine("After the rearrangement procedure completes, what crate ends up on top of each stack moving single crates?");
            builder.AppendLine($"{string.Join(string.Empty, stacks.Select(e => e.Value.Peek()))}");
            builder.AppendLine();

            stacks = parser.ParseStacks();

            RearrangeRanged(stacks, parser.ParseInstructions());

            builder.AppendLine("After the rearrangement procedure completes, what crate ends up on top of each stack moving multiple crates at once?");
            builder.AppendLine($"{string.Join(string.Empty, stacks.Select(e => e.Value.Peek()))}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static void RearrangeSingle(IDictionary<int, Stack<char>> stacks, IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
                for (int i = 0; i < instruction.Amount; i++)
                    stacks[instruction.Destination].Push(stacks[instruction.Source].Pop());

        }

        private static void RearrangeRanged(IDictionary<int, Stack<char>> stacks, IEnumerable<Instruction> instructions)
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
    }
}
