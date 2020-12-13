using System;
using System.Collections.Generic;
using AdventOfCode2020.Day13Stuff;

namespace AdventOfCode2020
{
    public static class Day13
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day13.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            BusScheduler bus = new BusScheduler(input);
            int result = bus.CalculateWaitingTime();

            Console.WriteLine("Result: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            BusScheduler bus = new BusScheduler(input);
            long result = bus.CalculateSynchronicity();

            Console.WriteLine("Result: " + result);

        }

    }
}