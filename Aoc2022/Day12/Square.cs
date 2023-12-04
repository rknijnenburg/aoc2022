using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day12
{
    internal class Square
    {
        private IDictionary<Direction, Square> Neighbors { get; } = new Dictionary<Direction, Square>();

        public char Value { get; }

        public int Elevation { get; }
        public int? Distance { get; set; }

        public Square(Square? left, Square? top, char value)
        {
            AddNeighbor(Direction.Left, left);
            AddNeighbor(Direction.Top, top);
            left?.AddNeighbor(Direction.Right, this);
            top?.AddNeighbor(Direction.Bottom, this);

            Value = value;
            Elevation = value switch
            {
                'E' => 'z',
                'S' => 'a',
                _ => value
            } - 'a';
        }

        private void AddNeighbor(Direction direction, Square? square)
        {
            if (square != null)
                Neighbors.Add(direction, square);
        }

        public Square? GetNeighbor(Direction direction)
        {
            return Neighbors.ContainsKey(direction) ? Neighbors[direction] : null;
        }
    }
}
