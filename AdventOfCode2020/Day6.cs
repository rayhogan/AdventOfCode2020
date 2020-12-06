using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2020.Day6Stuff;

namespace AdventOfCode2020
{
    public static class Day6
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day6.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            int count = CustomCustoms.GetGroupAnswers(input);


            Console.WriteLine("Positive Answers: "+count);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            int count = CustomCustoms.GetCommonGroupPositives(input);

            Console.WriteLine("Common Positive Answers: " + count);


        }


    }
}