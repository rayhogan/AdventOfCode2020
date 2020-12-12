using System;
using AdventOfCode2020.Day11Stuff;

namespace AdventOfCode2020
{
    public static class Day11
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day11.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            SeatSorter sorter = new SeatSorter(input);
            int result = sorter.PartOne();

            Console.WriteLine("Occupied Seats: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            SeatSorter sorter = new SeatSorter(input);
            int result = sorter.PartTwo();

            Console.WriteLine("Occupied Seats: " + result);

        }

    }
}