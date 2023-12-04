namespace Aoc2022.Day08
{
    internal class Tree
    {
        public int Height { get; }
        
        public bool Visible => GetVisible();

        public int ScenicScore => GetScenicScore();

        private IDictionary<Direction, Tree> Neighbors { get; } = new Dictionary<Direction, Tree>();

        public Tree(int height, Tree? left, Tree? top)
        {
            Height = height;

            AddNeighbor(Direction.Left, left);
            AddNeighbor(Direction.Top, top);
            left?.AddNeighbor(Direction.Right, this);
            top?.AddNeighbor(Direction.Bottom, this);
        }

        private void AddNeighbor(Direction direction, Tree? tree)
        {
            if (tree != null)
                Neighbors.Add(direction, tree);
        }

        private Tree? GetNeighbor(Direction direction)
        {
            return Neighbors.ContainsKey(direction) ? Neighbors[direction] : null;
        }
        
        private bool GetVisible()
        {
            foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
            {
                var neighbor = GetNeighbor(direction);

                while (neighbor != null)
                {
                    if (neighbor.Height >= Height)
                        break;

                    neighbor = neighbor.GetNeighbor(direction);
                }

                if (neighbor == null)
                    return true;
            }

            return false;
        }

        private int GetScenicScore()
        {
            var score = 1;

            foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
            {
                var trees = 0;
                var neighbor = GetNeighbor(direction);
                
                while (neighbor != null)
                {
                    trees++;

                    if (neighbor.Height >= Height)
                        break;

                    neighbor = neighbor.GetNeighbor(direction);
                }

                score *= trees;
            }

            return score;
        }

    }
}
