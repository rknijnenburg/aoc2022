using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day11
{
    internal static class MonkeyInTheMiddle
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 11: Monkey in the Middle");
            builder.AppendLine();

            var parser = new Parser();
            
            builder.AppendLine("What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?");
            builder.AppendLine($"{GetMonkeyBusiness(parser.Parse(), 20, true)}");
            builder.AppendLine();
            
            builder.AppendLine("what is the level of monkey business after 10000 rounds?");
            builder.AppendLine($"{GetMonkeyBusiness(parser.Parse(), 10000, false)}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static long GetMonkeyBusiness(IEnumerable<Monkey> monkeys, int rounds, bool useWorryReduction)
        {
            var inspections = GetInspections(monkeys, rounds, useWorryReduction);

            return inspections
                .OrderByDescending(e => e)
                .Take(2)
                .Aggregate(1L, (a, i) => a * i);
        }

        private static IEnumerable<long> GetInspections(IEnumerable<Monkey> monkeys, int rounds, bool useWorryReduction)
        {
            var map = monkeys.ToDictionary(e => e.Number, e => e);
            var product = monkeys.Aggregate(1, (a, m) => a * m.Test);

            for (int r = 0; r < rounds; r++)
            {
                foreach (var monkey in map.Values)
                {
                    while (monkey.Pop(product, useWorryReduction) is { } move)
                        map[move.Monkey].Push(move.Level);
                }
            }

            return map.Values.Select(e => e.Inspections);
        }
    }
}
