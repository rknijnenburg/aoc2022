using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Aoc2022.Day02;
using Aoc2022.Day04;
using Aoc2022.Day07;

namespace Aoc2022.Day13
{
    internal class DistressSignal: IProblem
    {
        public string Name => "Distress Signal";
        public int Day => 13;

        private readonly List<JsonArray> packets = new();

        public DistressSignal()
        {
            var input = File.ReadAllLines("Day13/input.txt");

            foreach (var line in input)
                if (!string.IsNullOrEmpty(line))
                    packets.Add((JsonArray)(JsonNode.Parse(line) ?? new JsonArray()));
        }

        public string SolvePart1()
        {
            return GetSumIndicesCorrectPairs(packets)
                .ToString();
    }

        public string SolvePart2()
        {
            return GetDecoderKey(packets)
                .ToString();
        }

        private static int GetSumIndicesCorrectPairs(IEnumerable<JsonArray> packets)
        {
            var pairs = packets.Chunk(2).ToArray();
            var sum = 0;

            for (int i = 0; i < pairs.Length; i++)
            {
                if (CompareOrder(pairs[i][0], pairs[i][1]) <= 0)
                    sum += (i + 1);
            }

            return sum;
        }

        private int GetDecoderKey(List<JsonArray> packets)
        {
            var div1 = (JsonArray)JsonArray.Parse("[[2]]");
            var div2 = (JsonArray)JsonArray.Parse("[[6]]");

            packets.AddRange(new []{ div1, div2 });
            packets.Sort(CompareOrder);

            return (packets.IndexOf(div1) + 1) * (packets.IndexOf(div2) + 1);
        }

        private static int CompareOrder(JsonArray left, JsonArray right)
        {
            for (int i = 0; i < Math.Max(left.Count, right.Count); i++)
            {
                if (i == left.Count)
                    return -1;
                if (i == right.Count)
                    return 1;

                if (left[i] is JsonValue vl && right[i] is JsonValue vr)
                {
                    var l = vl.GetValue<int>();
                    var r = vr.GetValue<int>();

                    if (l != r)
                        return l - r;
                }
                else
                {
                    var l = left[i] is JsonArray ? (JsonArray)left[i] : new JsonArray(JsonValue.Create(left[i].GetValue<int>()));
                    var r = right[i] is JsonArray ? (JsonArray)right[i] : new JsonArray(JsonValue.Create(right[i].GetValue<int>()));

                    var c = CompareOrder(l, r);

                    if (c != 0)
                        return c;
                }
            }

            return 0;
        }



    }
}
