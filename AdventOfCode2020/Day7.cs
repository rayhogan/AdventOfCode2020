using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day7Stuff;

namespace AdventOfCode2020
{
    public static class Day7
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day7.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            BaggageProcessor processor = new BaggageProcessor(input);
            List<Bag> parentBags = processor.FindOuterParentBags("shiny gold");

            Console.WriteLine("Count: " + parentBags.Count());

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            BaggageProcessor processor = new BaggageProcessor(input);
            int count = processor.CountInnerBags("shiny gold");

            Console.WriteLine("Count: " + count);

        }
  
    }
}