using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day12
{
    internal class Parser
    {
        private readonly string[] input;

        public Parser()
        {
            input = File.ReadAllLines("Day12/input.txt");
        }

        public Square[][] Parse()
        {
            var grid = new List<List<Square>>();

            for (int r = 0; r < input.Length; r++)
            {
                grid.Add(new List<Square>());

                for (int c = 0; c < input[r].Length; c++)
                {
                    var value = input[r][c];
                    var top = r > 0 ? grid[r - 1][c] : null;
                    var left = c > 0 ? grid[r][c - 1] : null;

                    grid[r].Add(new Square(left, top, value));
                }
            }

            return grid.Select(e => e.ToArray()).ToArray();
        }
    }
}
