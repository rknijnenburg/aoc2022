using System.Text;

namespace Aoc2022.Day06
{
    internal class TuningTrouble: IProblem
    {

        public string Name => "Tuning Trouble";
        public int Day => 6;

        private readonly string stream;

        public TuningTrouble()
        {
            stream = File.ReadAllText("Day06/input.txt");
        }

        public string SolvePart1()
        {
            return FindFirstDistinctSeriesPos(stream, 4)
                .ToString();
        }

        public string SolvePart2()
        {
            return FindFirstDistinctSeriesPos(stream, 14)
                .ToString();
        }

        private int FindFirstDistinctSeriesPos(string stream, int distinctCharacters)
        {
            var queue = new Queue<char>();

            for (int i = 0; i < stream.Length; i++)
            {
                queue.Enqueue(stream[i]);

                if (queue.Count > distinctCharacters)
                    queue.Dequeue();

                if (queue.Distinct().Count() == distinctCharacters)
                    return i + 1;
            }

            return -1;
        }

    }
}
