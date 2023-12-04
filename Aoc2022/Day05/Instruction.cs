namespace Aoc2022.Day05
{
    internal class Instruction
    {
        public int Amount { get; }
        public int Source { get; }
        public int Destination { get; }

        public Instruction(int amount, int source, int destination)
        {
            Amount = amount;
            Source = source;
            Destination = destination;
        }
    }
}
