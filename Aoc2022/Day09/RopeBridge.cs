using System.Drawing;
using System.Text;

namespace Aoc2022.Day09
{
    internal class RopeBridge: IProblem
    {
        public string Name => "Rope Bridge";
        public int Day => 9;

        private readonly List<Step> steps = new();

        

        public RopeBridge()
        {
            var input = File.ReadAllLines("Day09/input.txt");

            foreach (string line in input)
                steps.Add(new Step(line));
        }

        public string SolvePart1()
        {
            return GetTailPositions(steps, 2)
                .Count()
                .ToString();
        }

        public string SolvePart2()
        {
            return GetTailPositions(steps, 10)
                .Count()
                .ToString();
        }

        private IEnumerable<Point> GetTailPositions(IEnumerable<Step> steps, int size)
        {
            Point[] rope = Enumerable.Repeat(new Point(0, 0), size).ToArray();

            HashSet<Point> positions = new HashSet<Point>();

            foreach (var step in steps)
            {
                for (var i = 0; i < step.Amount; i++)
                {
                    Move(rope, step.Direction);
                    positions.Add(rope.Last());
                }
            }

            return positions;
        }

        private void Move(Point[] rope, Direction direction)
        {
            rope[0] = Update(rope[0], direction);

            for (var i = 1; i < rope.Length; i++)
            {
                var dx = rope[i - 1].X - rope[i].X;
                var dy = rope[i - 1].Y - rope[i].Y;

                if (Math.Abs(dx) == 2 || Math.Abs(dy) == 2)
                {
                    rope[i].X += Math.Min(1, Math.Max(dx, -1));
                    rope[i].Y += Math.Min(1, Math.Max(dy, -1));
                }
            }
        }

        private Point Update(Point point, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    point.X--;
                    break;
                case Direction.Up:
                    point.Y++;
                    break;
                case Direction.Right:
                    point.X++;
                    break;
                case Direction.Down:
                    point.Y--;
                    break;
            }

            return point;
        }
    }
}
