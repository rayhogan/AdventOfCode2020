using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day1.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");
            int result = Calculate2Sum(input);

            Console.WriteLine("Result: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");
            int result = Calculate3Sum(input);

            Console.WriteLine("Result: " + result);

        }

        public static int Calculate2Sum(string[] input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i != j)
                    {
                        if ((Int32.Parse(input[i]) + Int32.Parse(input[j])) == 2020)
                        {
                            return Int32.Parse(input[i]) * Int32.Parse(input[j]);
                        }
                    }
                }
            }
            return result;
        }

        public static int Calculate3Sum(string[] input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i != j)
                    {
                        int sum = Int32.Parse(input[i]) + Int32.Parse(input[j]);

                        if (sum < 2020)
                        {
                            for (int k = 0; k < input.Length; k++)
                            {
                                if (k != i && k != j)
                                {
                                    if ((sum + Int32.Parse(input[k]) == 2020))
                                    {
                                        return Int32.Parse(input[i]) * Int32.Parse(input[j]) * Int32.Parse(input[k]);
                                    }
                                }
                            }
                        }
                    }
                }
               
            }
            return result;
        }


    }
}