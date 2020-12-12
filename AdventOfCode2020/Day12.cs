using System;
using System.Collections.Generic;
using AdventOfCode2020.Day12Stuff;

namespace AdventOfCode2020
{
    public static class Day12
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day12.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            ShipNavigator navi = new ShipNavigator(input);
            int result = navi.Part1Distance();

            Console.WriteLine("Distance: " + result);
        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            ShipNavigator navi = new ShipNavigator(input);
            int result = navi.Part2Distance();

            Console.WriteLine("Distance: " + result);

        }

    }
}