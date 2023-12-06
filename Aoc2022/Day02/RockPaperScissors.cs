using System.Text;

namespace Aoc2022.Day02
{
    internal class RockPaperScissors: IProblem
    {
        private readonly string[] input;

        public RockPaperScissors()
        {
            input = File.ReadAllLines("Day02/input.txt");
        }
        
        public string Name => "Rock Paper Scissors";
        public int Day => 2;
        public string SolvePart1()
        {
            var rounds = new List<ResponseRound>();

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    rounds.Add(new ResponseRound(line[0], line[2]));

            return rounds
                .Sum(e => e.Score)
                .ToString();
        }

        public string SolvePart2()
        {
            var rounds = new List<ResultRound>();

            foreach (var line in input)
                if (!string.IsNullOrWhiteSpace(line))
                    rounds.Add(new ResultRound(line[0], line[2]));

            return rounds
                .Sum(e => e.Score)
                .ToString();
        }

    }
}
