using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Aoc2022.Day02;

namespace Aoc2022.Day15
{
    internal class Parser
    {
        private readonly string input;

        public Parser()
        {
            input = File.ReadAllText("Day15/input.txt");
        }

        public IEnumerable<Sensor> Parse()
        {
            var sensors = new List<Sensor>();

            // not optimal but good for practice
            var regex = new Regex(@"Sensor at x=(?<sx>-?[\d]*), y=(?<sy>-?[\d]*): closest beacon is at x=(?<bx>-?[\d]*), y=(?<by>-?[\d]*)", RegexOptions.None);
            var matches = regex.Matches(input);

            for (int i = 0; i < matches.Count; i++)
            {
                var groups = matches[i].Groups;

                var sensor = new Point(Convert.ToInt32(groups["sx"].Value), Convert.ToInt32(groups["sy"].Value));
                var beacon = new Point(Convert.ToInt32(groups["bx"].Value), Convert.ToInt32(groups["by"].Value));
                
                sensors.Add(new Sensor(sensor, beacon));
            }

            return sensors;
        }
    }
}
