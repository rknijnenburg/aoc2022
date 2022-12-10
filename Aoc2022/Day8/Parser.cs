using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day8
{
    internal class Parser
    {
        private string[]? input = null;

        private void Load()
        {
            input ??= File.ReadAllLines("Day8/input.txt");
        }

        public Tree[][] Parse()
        {
            Load();

            var grid = new List<List<Tree>>();

            for (int r = 0; r < input.Length; r++)
            {
                grid.Add(new List<Tree>());

                for (int c = 0; c < input[r].Length; c++)
                {
                    var height = Convert.ToInt32(input[r][c]);
                    var top = r > 0 ? grid[r - 1][c] : null;
                    var left = c > 0 ? grid[r][c - 1] : null;
                    
                    grid[r].Add(new Tree(height, top, left));
                }
            }

            return grid.Select(e => e.ToArray()).ToArray();
        }
    }
}
