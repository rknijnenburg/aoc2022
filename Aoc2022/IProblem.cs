using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022
{
    public interface IProblem
    {
        string Name { get; }
        int Day { get; }

        string SolvePart1();
        string SolvePart2();
    }
}
