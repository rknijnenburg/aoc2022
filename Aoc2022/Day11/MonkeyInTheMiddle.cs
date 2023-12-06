using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aoc2022.Day11
{
    internal class MonkeyInTheMiddle: IProblem
    {


        public string Name => "Monkey in the Middle";
        public int Day => 11;

        private readonly string input;
        private readonly Regex regex;

        public MonkeyInTheMiddle()
        {
            input = File.ReadAllText("Day11/input.txt");

            // not optimal but good for practice
            regex = new Regex(
                @"Monkey (?<monkey>[\d]*):\n[\s]*Starting items: (?<items>([\d]*,?\s?)*)\n[\s]*Operation: new = (?<of>(old)|[\d]*)\s(?<oo>.?)\s(?<os>(old)|[\d]*)\n[\s]*Test: divisible by (?<test>[\d]*)\n[\s]*If true: throw to monkey (?<td>[\d]*)\n[\s]*If false: throw to monkey (?<fd>[\d]*)", 
                RegexOptions.Compiled
            );
        }

        public string SolvePart1()
        {
            var monkeys = BuildMonkeys();

            return GetMonkeyBusiness(monkeys, 20, true).ToString();
        }

        public string SolvePart2()
        {
            var monkeys = BuildMonkeys();

            return GetMonkeyBusiness(monkeys, 10000, false).ToString();
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

        public IEnumerable<Monkey> BuildMonkeys()
        {
            var monkeys = new List<Monkey>();
            var matches = regex.Matches(input);

            foreach (var match in matches.ToArray())
            {
                var monkey = Convert.ToInt32(match.Groups["monkey"].Value);
                var items = match.Groups["items"].Value.Split(',').Select(e => Convert.ToInt64(e.Trim())).ToArray();
                var operation = match.Groups["oo"].Value[0];
                var os1 = match.Groups["of"].Value;
                var os2 = match.Groups["os"].Value;
                var test = Convert.ToInt32(match.Groups["test"].Value);
                var td = Convert.ToInt32(match.Groups["td"].Value);
                var fd = Convert.ToInt32(match.Groups["fd"].Value);

                monkeys.Add(BuildMonkey(monkey, items, os1, operation, os2, test, td, fd));
            }

            return monkeys;
        }

        public Monkey BuildMonkey(int monkey, long[] items, string os1, char operation, string os2, int test, int td, int fd)
        {
            var move = (long level, int product, bool useWorryReduction) =>
            {
                var v1 = os1 == "old" ? level : Convert.ToInt32(os1);
                var v2 = os2 == "old" ? level : Convert.ToInt32(os2);

                switch (operation)
                {
                    case '*':
                        level = v1 * v2;
                        break;
                    case '+':
                        level = v1 + v2;
                        break;
                    default:
                        throw new Exception("Unhandled operator");
                }

                if (useWorryReduction)
                    level = (long)Math.Floor(level / 3f);

                level %= product;

                return new Move(level % test == 0 ? td : fd, level);
            };

            return new Monkey(monkey, test, items, move);
        }
    }
}
