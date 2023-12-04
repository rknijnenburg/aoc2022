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
using System.Threading.Tasks;

namespace Aoc2022.Day15
{
    internal static class BeaconExclusionZone
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 15: Beacon Exclusion Zone");
            builder.AppendLine();

            var sensors = new Parser().Parse();
            
            builder.AppendLine("In the row where y=2000000, how many positions cannot contain a beacon?");
            builder.AppendLine($"{CountCoveredPoints(sensors, 2000000)}");
            builder.AppendLine();

            builder.AppendLine("Find the only possible position for the distress beacon. What is its tuning frequency?");
            builder.AppendLine($"{FindUncoveredFrequency(sensors, 4000000)}");
            builder.AppendLine();

            return builder.ToString();
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

