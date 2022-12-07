using System.Text;

namespace Aoc2022.Day2
{
    internal static class RockPaperScissors
    {
        public static string Solve()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Day 2: Rock Paper Scissors");
            builder.AppendLine();

            Parser parser = new Parser();

            var responseRounds = parser.ParseResponseRounds();
            
            builder.AppendLine("What would your total score be if everything goes exactly according to your strategy guide using the second column as the response?");
            builder.AppendLine($"{responseRounds.Sum(e => e.Score)}");
            builder.AppendLine();

            var resultRounds = parser.ParseResultRounds();

            builder.AppendLine("what would your total score be if everything goes exactly according to your strategy guide using the second column as the result?");
            builder.AppendLine($"{resultRounds.Sum(e => e.Score)}");
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
