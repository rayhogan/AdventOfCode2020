using System;
using System.Collections.Generic;
using AdventOfCode2020.Day15Stuff;

namespace AdventOfCode2020
{
    public static class Day15
    {
        public static void Run()
        {

            var input = new[] { 0, 20, 7, 16, 1, 18, 15 };
            Part1(input);
            Part2(input);
        }

        public static void Part1(int[] input)
        {
            Helper.PrintChallengePart("Part 1");

            ElvishMemory elfGame = new ElvishMemory(input);
            long result = elfGame.FindSpokenNumber(2020);

            Console.WriteLine("Number: " + result);

        }

        public static void Part2(int[] input)
        {
            Helper.PrintChallengePart("Part 2");

            ElvishMemory elfGame = new ElvishMemory(input);
            long result = elfGame.FindSpokenNumber(30000000);

            Console.WriteLine("Number: " + result);

        }

    }
}
