namespace Aoc2022.Day09
{
    internal class Parser
    {
        private readonly string[] input;

        private static readonly Dictionary<char, Direction> directions = new()
        {
            { 'L', Direction.Left },
            { 'U', Direction.Up },
            { 'R', Direction.Right },
            { 'D', Direction.Down }
        };

        public Parser()
        {
            input = System.IO.File.ReadAllLines("Day09/input.txt");
        }
        
        public IEnumerable<Step> Parse()
        {
            var result = new List<Step>();

            foreach (string line in input)
            {
                var slices = line.Split(" ");
                var direction = directions[slices[0].Trim()[0]];
                var amount = Convert.ToInt32(slices[1]);
                result.Add(new Step(direction, amount));
            }

            return result;
        }

    }
}
