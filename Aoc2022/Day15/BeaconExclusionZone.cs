using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aoc2022.Day15
{
    internal class BeaconExclusionZone: IProblem
    {
        public string Name => "Beacon Exclusion Zone";
        public int Day => 15;

        private readonly List<Sensor> sensors = new();
        public BeaconExclusionZone()
        {
            var input = File.ReadAllText("Day15/input.txt");

            // not optimal but good for practice
            var regex = new Regex(
                @"Sensor at x=(?<sx>-?[\d]*), y=(?<sy>-?[\d]*): closest beacon is at x=(?<bx>-?[\d]*), y=(?<by>-?[\d]*)", 
                RegexOptions.None
            );
            var matches = regex.Matches(input);

            for (int i = 0; i < matches.Count; i++)
            {
                var groups = matches[i].Groups;

                var sensor = new Point(Convert.ToInt32(groups["sx"].Value), Convert.ToInt32(groups["sy"].Value));
                var beacon = new Point(Convert.ToInt32(groups["bx"].Value), Convert.ToInt32(groups["by"].Value));

                sensors.Add(new Sensor(sensor, beacon));
            }
        }

        public string SolvePart1()
        {
            return CountCoveredPoints(sensors, 2000000)
                .ToString();
        }

        public string SolvePart2()
        {
            return FindUncoveredFrequency(sensors, 4000000)
                .ToString();
        }

        private static BigInteger FindUncoveredFrequency(IEnumerable<Sensor> sensors, int max)
        {
            for (var y = max; y >= 0; y--)
            {
                var selection = sensors
                    .Where(s => s.Bottom <= y && y <= s.Top)
                    .OrderBy(e => e.GetLeftest(y))
                    .ToList();

                var marker = 0;

                foreach (var sensor in selection)
                {
                    var rightest = sensor.GetRightest(y).Value;
                    var leftest = sensor.GetLeftest(y).Value;

                    if (leftest > marker + 1)
                        return BigInteger.Multiply(4000000, (marker + 1)) + y;

                    if (rightest > marker)
                        marker = sensor.GetRightest(y).Value;
                }
            }

            return 0;
        }

        private static int CountCoveredPoints(IEnumerable<Sensor> sensors, int y)
        {
            var selection = sensors
                .Where(s => s.Bottom <= y && y <= s.Top)
                .OrderBy(e => e.GetLeftest(y))
                .ToList();

            var marker = selection.First().GetLeftest(y).Value;
            var points = 0;

            foreach (var sensor in selection)
            {
                var rightest = sensor.GetRightest(y).Value;
                var leftest = sensor.GetLeftest(y).Value;

                if (rightest > marker)
                {
                    points += rightest - Math.Max(marker, leftest);
                    marker = sensor.GetRightest(y).Value;
                }
            }

            return points;
        }


    }
}

