using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Aoc2022.Day11
{
    internal class Monkey
    {
        private Func<long, int, bool, Move> next;

        public int Number { get; }

        public int Test { get; }

        private readonly Queue<long> items = new Queue<long>();

        public long Inspections { get; private set; }

        public Monkey(int number, int test, IEnumerable<long> items, Func<long, int, bool, Move> next)
        {
            this.Number = number;
            foreach (var item in items)
                this.items.Enqueue(item);
            this.next = next;
            this.Test = test;
        }

        public Move? Pop(int product, bool useWorryReduction)
        {
            if (items.Count > 0)
            {
                Inspections++;

                var item = items.Dequeue();

                return next.Invoke(item, product, useWorryReduction);
            }

            return null;
        }

        public void Push(long item)
        {
            items.Enqueue(item);
        }

        //public IEnumerable<Throw> Throw()
        //{
        //    Inspected += items.Count;

        //    var result = new List<Throw>();

        //    foreach (var item in items)
        //        result.Add(next.Invoke(item));

        //    items.Clear();
            
        //    return result;
        //}

        //public void Catch(BigInteger item)
        //{
        //    items.Add(item);
        //}
    }
}
