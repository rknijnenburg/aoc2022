using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Aoc2022.Day02;
using Aoc2022.Day05;
using static System.Net.Mime.MediaTypeNames;

namespace Aoc2022.Day10
{
    internal static class CathodeRayTube
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 10: Cathode-Ray Tube");
            builder.AppendLine();

            var instructions = new Parser().Parse();
            var history = BuildHistory(instructions);

            builder.AppendLine("Find the signal strength during the 20th, 60th, 100th, 140th, 180th, and 220th cycles. What is the sum of these six signal strengths?");
            builder.AppendLine($"{history.Where(e => (e.Key + 20) % 40 == 0).Sum(e => e.Key * e.Value)}");
            builder.AppendLine();

            builder.AppendLine("Render the image given by your program.What eight capital letters appear on your CRT?");

            foreach (var c in history.Keys)
            {
                var pos = c % 40;

                builder.Append(pos - 1 <= history[c] && history[c] <= pos + 1 ? '#' : '.');

                if ((c + 1) % 40 == 0)
                    builder.AppendLine();
            }

            builder.AppendLine();

            return builder.ToString();
        }

        private static Dictionary<int, int> BuildHistory(IEnumerable<string> instructions)
        {
            var result = new Dictionary<int, int> { { 0, 0 } };
            var x = 1;
            var c = 1;

            foreach (var instruction in instructions)
            {
                var duration = instruction.Trim() == "noop" ? 1 : 2;

                for (int i = 1; i <= duration; i++)
                {
                    if (i == duration)
                    {
                        if (instruction.StartsWith("addx"))
                        {
                            var value = Convert.ToInt32(instruction.Split(" ")[1]);

                            x += value;
                        }
                    }

                    result.Add(c, x);

                    c++;
                }
            }

            return result;
        }
    }
}
