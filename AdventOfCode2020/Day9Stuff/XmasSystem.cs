using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day9Stuff
{
    public class XmasSystem
    {
        private List<long> DataStream = new List<long>();
        public XmasSystem(string[] input)
        {
            foreach (string s in input)
            {
                DataStream.Add(long.Parse(s));
            }
        }

        public long FindInvalidData(int preamble) // Part I
        {
            long output = 0;
            for (int i = preamble; i < DataStream.Count; i++)
            {
                List<long> sublist = DataStream.GetRange(i - preamble, preamble);
                if (!FindSum(sublist, DataStream[i]))
                    return DataStream[i];
            }
            return output;
        }

        private bool FindSum(List<long> input, long target)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (i != j)
                    {
                        if (input[i] + input[j] == target)
                            return true;
                    }
                }
            }
            return false;
        }
        public long FindContiguousSet(long target) // Part II
        {
            var result = FindSequence(target);
            return result.Min() + result.Max();
        }
        private List<long> FindSequence(long target)
        {
            List<long> output = new List<long>();
            for (int i = 0; i < DataStream.Count; i++)
            {
                long counter = DataStream[i];
                for (int j = i + 1; j < DataStream.Count; j++)
                {
                    counter += DataStream[j];

                    if (counter == target)
                    {
                        output = DataStream.GetRange(i, (j-i));
                        return output;
                    }
                    else if (counter > target)
                    {
                        break;
                    }
                }
            }
            return output;
        }
    }
}
