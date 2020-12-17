using System;
using System.Collections.Generic;
using AdventOfCode2020.Day17Stuff;

namespace AdventOfCode2020
{
    public static class Day17
    {
        public static void Run()
        {

            string[] input = Helper.ParseInput(@"Inputs\\Day17.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            SpaceMapper mapper = new SpaceMapper(input);
            int result = mapper.CountActivePart1();

            Console.WriteLine("Active Cubes: " + result);
        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            SpaceMapper mapper = new SpaceMapper(input);
            int result = mapper.CountActivePart2();

            Console.WriteLine("Active Cubes: " + result);

        }

    }
}
