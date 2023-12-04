using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day15
{
    internal static class Calculator
    {
        public static int GetManhattanDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        public static int GetManhattanDistance(Point p1, Point p2)
        {
            return GetManhattanDistance(p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
