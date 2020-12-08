using System;
using AdventOfCode2020.Day8Stuff;

namespace AdventOfCode2020
{
    public static class Day8
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day8.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            GameBoy gameBoy = new GameBoy(input);
            int accum = gameBoy.FindRepeatInstructions();

            Console.WriteLine("Accumulator: " + accum);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            GameBoy gameBoy = new GameBoy(input);
            int accum = gameBoy.FixBootInstructions();

            Console.WriteLine("Accumulator: " + accum);

        }

    }
}