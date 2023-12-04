using System.Diagnostics;
using System.Runtime.CompilerServices;

void Execute(Func<string> f)
{
    Stopwatch stopwatch = Stopwatch.StartNew();

    Console.Out.WriteLine("------------------------------------------------------------------------------------");
    Console.Out.Write(f.Invoke());

    Console.Out.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
    Console.Out.WriteLine();
}

//Execute(Aoc2022.Day01.CalorieCounting.Solve);
//Execute(Aoc2022.Day02.RockPaperScissors.Solve);
//Execute(Aoc2022.Day03.RucksackReorganization.Solve);
//Execute(Aoc2022.Day04.CampCleanup.Solve);
//Execute(Aoc2022.Day05.SupplyStacks.Solve);
//Execute(Aoc2022.Day06.TuningTrouble.Solve);
//Execute(Aoc2022.Day07.NoSpaceLeftOnDevice.Solve);
//Execute(Aoc2022.Day08.TreetopTreeHouse.Solve);
//Execute(Aoc2022.Day09.RopeBridge.Solve);
//Execute(Aoc2022.Day10.CathodeRayTube.Solve);
//Execute(Aoc2022.Day11.MonkeyInTheMiddle.Solve);
//Execute(Aoc2022.Day12.HillClimbingAlgorithm.Solve);
//Execute(Aoc2022.Day13.DistressSignal.Solve);
//Execute(Aoc2022.Day14.RegolithReservoir.Solve);
//Execute(Aoc2022.Day15.BeaconExclusionZone.Solve);
Execute(Aoc2022.Day16.ProboscideaVolcanium.Solve);

Console.ReadKey();

