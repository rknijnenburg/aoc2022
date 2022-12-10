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

Execute(Aoc2022.Day01.CalorieCounting.Solve);
Execute(Aoc2022.Day02.RockPaperScissors.Solve);
Execute(Aoc2022.Day03.RucksackReorganization.Solve);
Execute(Aoc2022.Day04.CampCleanup.Solve);
Execute(Aoc2022.Day05.SupplyStacks.Solve);
Execute(Aoc2022.Day06.TuningTrouble.Solve);
Execute(Aoc2022.Day07.NoSpaceLeftOnDevice.Solve);
Execute(Aoc2022.Day09.RopeBridge.Solve);

Console.ReadKey();

