namespace Aoc2022.Day5
{
    internal class Instruction
    {
        private readonly string data;

        public int Amount { get; }
        public int Source { get; }
        public int Destination { get; }

        public Instruction(string line)
        {
            this.data = line;

            var split = data.Split(" ");

            Amount = Convert.ToInt32(split[1]);
            Source = Convert.ToInt32(split[3]);
            Destination = Convert.ToInt32(split[5]);
        }
    }
}
