using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2020.Day5Stuff;

namespace AdventOfCode2020
{
    public static class Day5
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day5.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");
            
            AeroplaneManager aeroplane = new AeroplaneManager(input);            
            int highestSeatID = aeroplane.HighestSeatID();

            Console.WriteLine("Highest Seat ID: "+ highestSeatID);  

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            AeroplaneManager aeroplane = new AeroplaneManager(input);
            int mySeatID = aeroplane.FindMySeat();

            Console.WriteLine("My Seat ID" + mySeatID);
        }


    }
}