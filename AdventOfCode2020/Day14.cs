using System;
using System.Collections.Generic;
using AdventOfCode2020.Day14Stuff;

namespace AdventOfCode2020
{
    public static class Day14
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day14.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            BitmaskManager bits = new BitmaskManager(input);
            long sum = bits.SumMemoryValues();

            Console.WriteLine("Memory Sum: " + sum);


        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            BitmaskManager bits = new BitmaskManager(input);
            long sum = bits.SumMemoryValuesVersion2();

            Console.WriteLine("Version 2: " + sum);
        }

    }
}