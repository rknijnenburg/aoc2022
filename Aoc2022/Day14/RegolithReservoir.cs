using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Aoc2022.Day14
{
    internal class RegolithReservoir: IProblem
    {
        public string Name => "Regolith Reservoir";
        public int Day => 14;

        private readonly Grid grid;


        public RegolithReservoir()
        {
            var input = File.ReadAllLines("Day14/input.txt");

            var rocks = new List<(Point, Point)>();

            foreach (var line in input)
                rocks.AddRange(ParseRocks(line));

            grid = new Grid(rocks);
        }

        public string SolvePart1()
        {
            return grid
                .Simulate(new Point(500, 0), false)
                .ToString();
        }

        public string SolvePart2()
        {
            return grid
                .Simulate(new Point(500, 0), true)
                .ToString();
        }

        private IEnumerable<(Point, Point)> ParseRocks(string line)
        {
            var slices = line.Split("->");
            var points = new List<Point>();

            foreach (var slice in slices)
            {
                var coordinates = slice.Split(",").Select(e => Convert.ToInt32(e.Trim())).ToArray();
                points.Add(new Point(coordinates[0], coordinates[1]));
            }

            for (var i = 0; i < points.Count - 1; i++)
                yield return (points[i], points[i + 1]);
        }
    }
}
