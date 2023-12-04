using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day11
{
    internal class Move
    {
        public int Monkey { get; }
        public long Level { get; }
        
        public Move(int monkey, long level)
        {
            Monkey = monkey;
            Level = level;
        }
    }
}
