using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Aoc2022
{
    public partial class Program
    {
        private static readonly Stopwatch stopwatch = Stopwatch.StartNew();

        private static void Solve<TProblem>()
            where TProblem : IProblem
        {
            stopwatch.Restart();

            var problem = Activator.CreateInstance<TProblem>();

            Console.Out.Write($"|{problem.Name,32}");
            Console.Out.Write($"|{problem.Day,4}");
            Console.Out.Write($"|{stopwatch.Elapsed,12:mm':'ss':'ffff}");

            stopwatch.Restart();

            Console.Out.Write($"|{problem.SolvePart1(),20}");
            Console.Out.Write($"|{stopwatch.Elapsed,12:mm':'ss':'ffff}");

            stopwatch.Restart();

            Console.Out.Write($"|{problem.SolvePart2(),20}");
            Console.Out.Write($"|{stopwatch.Elapsed,12:mm':'ss':'ffff}");
            Console.Out.Write("|");
            Console.Out.WriteLine();
        }

        public static void Main(string[] args)
        {
            Console.Out.Write($"|{"Name",32}");
            Console.Out.Write($"|{"Day",4}");
            Console.Out.Write($"|{"Init",12}");
            Console.Out.Write($"|{"Part 1",20}");
            Console.Out.Write($"|{"Elapsed",12}");
            Console.Out.Write($"|{"Part 2",20}");
            Console.Out.Write($"|{"Elapsed",12}");
            Console.Out.Write("|");
            Console.Out.WriteLine();
            Console.Out.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            Solve<Day01.CalorieCounting>();
            Solve<Day02.RockPaperScissors>();
            Solve<Day03.RucksackReorganization>();
            Solve<Day04.CampCleanup>();
            Solve<Day05.SupplyStacks>();
            Solve<Day06.TuningTrouble>();
            Solve<Day07.NoSpaceLeftOnDevice>();
            Solve<Day08.TreetopTreeHouse>();
            Solve<Day09.RopeBridge>();
            Solve<Day10.CathodeRayTube>();
            Solve<Day11.MonkeyInTheMiddle>();
            Solve<Day12.HillClimbingAlgorithm>();
            Solve<Day13.DistressSignal>();
            Solve<Day14.RegolithReservoir>();
            Solve<Day15.BeaconExclusionZone>();
            //Solve<Day16.ProboscideaVolcanium>();

            Console.ReadKey();

            Console.ReadKey();
        }
    }

}
