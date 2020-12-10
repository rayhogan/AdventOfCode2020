using System;
using AdventOfCode2020.Day10Stuff;

namespace AdventOfCode2020
{
    public static class Day10
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day10.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            VoltageAdaptor volts = new VoltageAdaptor(input);
            int result = volts.CalculateDifferences();

            Console.WriteLine("Volts Difference: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            VoltageAdaptor volts = new VoltageAdaptor(input);
            ulong result = volts.CalculateCombinations();

            Console.WriteLine("Combos: " + result);

        }

    }
}