using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day10Stuff
{
    public class VoltageAdaptor
    {
        private List<int> Adaptors = new List<int>();
        public VoltageAdaptor(string[] input)
        {
            Adaptors = input.Select(i => Int32.Parse(i)).ToList();
            Adaptors.Add(0);
            Adaptors.Sort();
        }

        public int CalculateDifferences()
        {
            int oneDifference = 0;
            int threeDifference = 1;

            for (int i = 1; i < Adaptors.Count; i++)
            {
                if (Adaptors[i] - Adaptors[i - 1] == 1)
                    oneDifference++;
                else if (Adaptors[i] - Adaptors[i - 1] == 3)
                    threeDifference++;
                else
                    throw new Exception("ERROR - You can't skip an adaptor!");
            }

            return oneDifference * threeDifference;
        }

        public ulong CalculateCombinations()
        {
            // Unsigned to save some memory
            ulong[] combos = new ulong[Adaptors.Count];

            combos[0] = 1;
            for (var i = 1; i < Adaptors.Count; i++)
            {
                for (var j = i-3; j < i; j++)
                {
                    if (j >= 0)
                    {
                        if (Adaptors[i] - Adaptors[j] <= 3)
                        {
                            combos[i] += combos[j];
                        }
                    }
                }
            }
            return combos.Last();
        }
    }
}
