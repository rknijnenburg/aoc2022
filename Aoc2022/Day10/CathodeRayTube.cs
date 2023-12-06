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
    internal class CathodeRayTube: IProblem
    {
        public string Name => "Cathode-Ray Tube";
        public int Day => 10;

        private readonly Dictionary<int, int> history;

        public CathodeRayTube()
        {
            var input = File.ReadAllLines("Day10/input.txt")
                .Select(e => e.Trim())
                .ToArray();

            history = new Dictionary<int, int>();
            var x = 1;
            var c = 1;

            history.Add(x, c);

            foreach (var instruction in input)
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

                    c++;

                    history.Add(c, x);
                }
            }
        }

        public string SolvePart1()
        {
            return history
                .Where(e => (e.Key + 20) % 40 == 0)
                .Sum(e => e.Key * e.Value)
                .ToString();
        }

        public string SolvePart2()
        {
            var builder = new StringBuilder();

            foreach (var c in history.Keys)
            {
                var pos = (c - 1) % 40;

                builder.Append((pos - 1) <= history[c] && history[c] <= (pos + 1) ? '#' : '.');

                if (c % 40 == 0)
                    builder.AppendLine();
            }

            builder.AppendLine();

            var filename = $"output.8.txt";

            try
            {
                File.Delete(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            File.WriteAllText(filename, builder.ToString());

            return filename;
        }
}
}
