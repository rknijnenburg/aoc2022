using System.Text;

namespace Aoc2022.Day08
{
    internal class TreetopTreeHouse: IProblem
    {
        public string Name => "Treetop Tree House";
        public int Day => 8;

        private readonly Tree[][] trees;

        public TreetopTreeHouse()
        {
            var input = File.ReadAllLines("Day08/input.txt");
            
            trees = new Tree[input.Length][];

            for (int r = 0; r < input.Length; r++)
            {
                trees[r] = new Tree[input[r].Length];

                for (int c = 0; c < input[r].Length; c++)
                {
                    var height = Convert.ToInt32(input[r][c]);
                    var top = r > 0 ? trees[r - 1][c] : null;
                    var left = c > 0 ? trees[r][c - 1] : null;

                    trees[r][c] = new Tree(height, left, top);
                }
            }
        }

        public string SolvePart1()
        {
            return trees
                .SelectMany(e => e)
                .Count(e => e.Visible)
                .ToString();
        }

        public string SolvePart2()
        {
            return trees
                .SelectMany(e => e)
                .Max(e => e.ScenicScore)
                .ToString();
        }
    }
}
