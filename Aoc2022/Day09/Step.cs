namespace Aoc2022.Day09
{
    internal class Step
    {
        public Direction Direction { get; }
        public int Amount { get; }

        public Step(Direction direction, int amount)
        {
            Direction = direction;
            Amount = amount;
        }
    }
}
