using System.Text;

namespace Aoc2022.Day06
{
    internal static class TuningTrouble
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 6: Tuning Trouble");
            builder.AppendLine();

            var parser = new Parser();
            var stream = parser.Parse();

            builder.AppendLine("How many characters need to be processed before the first start-of-packet marker is detected?");
            builder.AppendLine($"{FindFirstDistinctSeriesPos(stream, 4)}");
            builder.AppendLine();

            builder.AppendLine("How many characters need to be processed before the first start-of-message marker is detected?");
            builder.AppendLine($"{FindFirstDistinctSeriesPos(stream, 14)}");
            builder.AppendLine();

            return builder.ToString();
        }

        private static int FindFirstDistinctSeriesPos(string stream, int distinctCharacters)
        {
            var queue = new Queue<char>();

            for (int i = 0; i < stream.Length; i++)
            {
                queue.Enqueue(stream[i]);

                if (queue.Count > distinctCharacters)
                    queue.Dequeue();

                if (queue.Distinct().Count() == distinctCharacters)
                    return i+1;
            }

            return -1;
        }
    }
}
