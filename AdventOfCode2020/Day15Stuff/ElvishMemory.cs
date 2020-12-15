using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day15Stuff
{
    public class ElvishMemory
    {
        private Dictionary<long, long> History = new Dictionary<long, long>();
        private long Position = 1L;
        public ElvishMemory(int[] input)
        {
            foreach (int i in input)
            {
                History.Add(i, Position);
                Position++;
            }
        }

        public long FindSpokenNumber(long target)
        {
            long lastSpoken = 0;
            Position++;

            while(Position <= target)
            {
                if(History.ContainsKey(lastSpoken))
                {
                    long newNumber = (Position - 1) - History[lastSpoken];
                    History[lastSpoken] = (Position - 1);
                    lastSpoken = newNumber;
                }
                else
                {
                    // New number, add it
                    History.Add(lastSpoken, Position - 1);
                    lastSpoken = 0;
                }
                Position++;
            }

            return lastSpoken;
        }


    }
}
