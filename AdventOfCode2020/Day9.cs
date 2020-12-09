using System;
using System.Linq;
using AdventOfCode2020.Day9Stuff;

namespace AdventOfCode2020
{
    public static class Day9
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day9.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            XmasSystem xmas = new XmasSystem(input);
            long result = xmas.FindInvalidData(25);

            Console.WriteLine("Invalid: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            XmasSystem xmas = new XmasSystem(input);
            long result = xmas.FindInvalidData(25);
            long sum = xmas.FindContiguousSet(result);

            Console.WriteLine("Contiguous Sum: " + sum);

        }

    }
}