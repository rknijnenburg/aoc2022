using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Aoc2022.Day02;

namespace Aoc2022.Day14
{
    internal class Parser
    {
        private readonly string[] input;

        public Parser()
        {
            input = File.ReadAllLines("Day14/input.txt")
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .ToArray();
        }

        public Grid Parse()
        {
            var rocks = new List<(Point, Point)>();

            foreach (var line in input)
                rocks.AddRange(ParseRocks(line));
            
            return new Grid(rocks);
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
