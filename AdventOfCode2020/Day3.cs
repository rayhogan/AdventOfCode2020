using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2020.Day3Stuff;

namespace AdventOfCode2020
{
    public static class Day3
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day3.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            TobogganSatNav satSav = new TobogganSatNav(input);
            int treeCount = satSav.RoutePlanner(3,1);

            Console.WriteLine("Trees Hit: " + treeCount);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            long treeCount = 1;
            TobogganSatNav satSav = new TobogganSatNav(input);

            treeCount = treeCount * satSav.RoutePlanner(1, 1);            
            treeCount = treeCount * satSav.RoutePlanner(3, 1);
            treeCount = treeCount * satSav.RoutePlanner(5, 1);
            treeCount = treeCount * satSav.RoutePlanner(7, 1);
            treeCount = treeCount * satSav.RoutePlanner(1, 2);

            Console.WriteLine("Trees Hit: " + treeCount);
        }


    }
}