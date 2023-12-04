using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Aoc2022.Day11
{
    internal class Parser
    {
        private string input;

        public Parser()
        {
            input = File.ReadAllText("Day11/input.txt");
        }

        public IEnumerable<Monkey> Parse()
        {
            var monkeys = new List<Monkey>();

            // not optimal but good for practice
            var regex = new Regex(@"Monkey (?<monkey>[\d]*):\n[\s]*Starting items: (?<items>([\d]*,?\s?)*)\n[\s]*Operation: new = (?<of>(old)|[\d]*)\s(?<oo>.?)\s(?<os>(old)|[\d]*)\n[\s]*Test: divisible by (?<test>[\d]*)\n[\s]*If true: throw to monkey (?<td>[\d]*)\n[\s]*If false: throw to monkey (?<fd>[\d]*)");
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
