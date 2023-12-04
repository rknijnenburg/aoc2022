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
    internal static class RegolithReservoir
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 14: Regolith Reservoir");
            builder.AppendLine();

            var grid = new Parser().Parse();

            builder.AppendLine("How many units of sand come to rest before sand starts flowing into the abyss below?");
            builder.AppendLine($"{grid.Simulate(new Point(500, 0), false)}");
            builder.AppendLine();

            grid.Reset();

            builder.AppendLine("How many units of sand come to rest until the source of the sand becomes blocked?");
            builder.AppendLine($"{grid.Simulate(new Point(500, 0), true)}");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
