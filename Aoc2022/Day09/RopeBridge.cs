using System.Drawing;
using System.Text;

namespace Aoc2022.Day09
{
    internal static class RopeBridge
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 9: Rope Bridge");
            builder.AppendLine();

            var parser = new Parser();
            var steps = parser.Parse().ToList();
            
            builder.AppendLine("How many positions does the tail of the rope visit at least once? (Length 2)");
            builder.AppendLine($"{GetTailPositions(steps, 2).Count()}");
            builder.AppendLine();

            builder.AppendLine("How many positions does the tail of the rope visit at least once? (Length 10)");
            builder.AppendLine($"{GetTailPositions(steps, 10).Count()}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static IEnumerable<Point> GetTailPositions(IEnumerable<Step> steps, int size)
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

        private static void Move(Point[] rope, Direction direction)
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

        private static Point Update(Point point, Direction direction)
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
