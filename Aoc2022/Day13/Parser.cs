using Aoc2022.Day12;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Aoc2022.Day13
{
    internal class Parser
    {
        private readonly string[] input;

        public Parser()
        {
            input = File.ReadAllLines("Day13/input.txt")
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .ToArray();
        }

        public IEnumerable<JsonArray> Parse()
        {
            var result = new List<JsonArray>();

            foreach (var line in input)
                result.Add((JsonArray) (JsonNode.Parse(line) ?? new JsonArray()));

            return result;
        }
    }
}
