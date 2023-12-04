using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day15
{
    internal class Sensor
    {
        public Point Position { get; }
        public Point Beacon { get; }
        public int Distance { get; }
        public int Left { get; }
        public int Top { get; }
        public int Right { get; }
        public int Bottom { get; }
        
        public Sensor(Point position, Point beacon)
        {
            Position = position;
            Beacon = beacon;
            Distance = Calculator.GetManhattanDistance(Position, Beacon);
            Left = Position.X - Distance;
            Top = Position.Y + Distance;
            Right = Position.X + Distance;
            Bottom = Position.Y - Distance;
        }

        public int? GetLeftest(int y)
        {
            var ry = Math.Abs(y - Position.Y);

            if (ry <= Distance)
                return Position.X - (Distance - ry);

            return null;
        }

        public int? GetRightest(int y)
        {
            var ry = Math.Abs(y - Position.Y);

            if (ry <= Distance)
                return Position.X + (Distance - ry);

            return null;
        }
    }
}
