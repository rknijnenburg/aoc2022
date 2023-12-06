using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aoc2022.Day12
{
    internal class HillClimbingAlgorithm: IProblem
    {
        public string Name => "Hill Climbing Algorithm";
        public int Day => 12;

        private readonly string[] input;

        public HillClimbingAlgorithm()
        {
            input = File.ReadAllLines("Day12/input.txt");
        }

        public string SolvePart1()
        {
            return GetShortestPath('S').ToString();
    }

        public string SolvePart2()
        {
            return GetShortestPath('a').ToString();
        }

        private int GetShortestPath(char finish)
        {
            var grid = BuildGrid();
            var squares = grid.SelectMany(e => e).ToList();
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

        private Square[][] BuildGrid()
        {
            var grid = new Square[input.Length][];

            for (int r = 0; r < input.Length; r++)
            {
                grid[r] = new Square[input[r].Length];

                for (int c = 0; c < input[r].Length; c++)
                {
                    var value = input[r][c];
                    var top = r > 0 ? grid[r - 1][c] : null;
                    var left = c > 0 ? grid[r][c - 1] : null;

                    grid[r][c] = new Square(left, top, value);
                }
            }

            return grid;

        }
    }
}
