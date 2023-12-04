using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Aoc2022.Day04;
using Aoc2022.Day07;

namespace Aoc2022.Day13
{
    internal static class DistressSignal
    {
        public static string Solve()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Day 13: Distress Signal");
            builder.AppendLine();

            var packets = new Parser().Parse().ToList();
            
            builder.AppendLine("Determine which pairs of packets are already in the right order. What is the sum of the indices of those pairs?");
            builder.AppendLine($"{GetSumIndicesCorrectPairs(packets)}");
            builder.AppendLine();

            builder.AppendLine("Organize all of the packets into the correct order. What is the decoder key for the distress signal?");
            builder.AppendLine($"{GetDecoderKey(packets)}");


            return builder.ToString();
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

        private static int GetDecoderKey(List<JsonArray> packets)
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
