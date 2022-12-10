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

Execute(Aoc2022.Day1.CalorieCounting.Solve);
Execute(Aoc2022.Day2.RockPaperScissors.Solve);
Execute(Aoc2022.Day3.RucksackReorganization.Solve);
Execute(Aoc2022.Day4.CampCleanup.Solve);
Execute(Aoc2022.Day5.SupplyStacks.Solve);
Execute(Aoc2022.Day6.TuningTrouble.Solve);
Execute(Aoc2022.Day7.NoSpaceLeftOnDevice.Solve);
Execute(Aoc2022.Day8.TreetopTreeHouse.Solve);

Console.ReadKey();

