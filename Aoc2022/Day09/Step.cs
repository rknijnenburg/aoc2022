namespace Aoc2022.Day09
{
    internal class Step
    {
        public Direction Direction { get; }
        public int Amount { get; }

        private static readonly Dictionary<char, Direction> directions = new()
        {
            { 'L', Direction.Left },
            { 'U', Direction.Up },
            { 'R', Direction.Right },
            { 'D', Direction.Down }
        };

        public Step(string line)
        {
            var slices = line.Split(" ");

            Direction = directions[slices[0].Trim()[0]];
            Amount = Convert.ToInt32(slices[1]);
        }
    }
}
