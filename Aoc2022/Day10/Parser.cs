using Aoc2022.Day09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day10
{
    internal class Parser
    {
        private string[]? input = null;
        private IEnumerable<string> Input => input ??= System.IO.File.ReadAllLines("Day10/input.txt");
        
        public IEnumerable<string> Parse()
        {
            return Input;
        }
    }
}
