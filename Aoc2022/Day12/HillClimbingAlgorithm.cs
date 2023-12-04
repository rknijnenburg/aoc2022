using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aoc2022.Day12
{
    internal static class HillClimbingAlgorithm
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 12: Hill Climbing Algorithm");
            builder.AppendLine();

            var parser = new Parser();

            builder.AppendLine("What is the fewest steps required to move from your current position to the location that should get the best signal?");
            builder.AppendLine($"{GetShortestPath(parser, 'S')}");
            builder.AppendLine();

            builder.AppendLine("What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?");
            builder.AppendLine($"{GetShortestPath(parser, 'a')}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static int GetShortestPath(Parser parser, char finish)
        {
            var squares = parser.Parse().SelectMany(e => e).ToList();
            var first = squares.Single(e => e.Value == 'E');
            first.Distance = 0;

            var queue = new Queue<Square>();
            queue.Enqueue(first);

            var last = squares.Where(e => e.Value == finish);
            
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
                {
                    var inspect = current.GetNeighbor(direction);

                    if (inspect is { Distance: null } && current.Elevation - inspect.Elevation <= 1)
                    {
                        inspect.Distance = current.Distance + 1;

                        queue.Enqueue(inspect);
                    }
                }
            }

            return last.Where(e => e.Distance != null).Min(e => e.Distance) ?? throw new Exception("Finish should have a distance");
        }

    }
}
