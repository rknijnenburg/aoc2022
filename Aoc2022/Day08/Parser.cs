namespace Aoc2022.Day08
{
    internal class Parser
    {
        private readonly string[] input;

        public Parser()
        {
            input = File.ReadAllLines("Day08/input.txt");
        }
        
        public Tree[][] Parse()
        {
            var grid = new List<List<Tree>>();

            for (int r = 0; r < input.Length; r++)
            {
                grid.Add(new List<Tree>());

                for (int c = 0; c < input[r].Length; c++)
                {
                    var height = Convert.ToInt32(input[r][c]);
                    var top = r > 0 ? grid[r - 1][c] : null;
                    var left = c > 0 ? grid[r][c - 1] : null;
                    
                    grid[r].Add(new Tree(height, left, top));
                }
            }

            return grid.Select(e => e.ToArray()).ToArray();
        }
    }
}
