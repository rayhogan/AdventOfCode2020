using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2020.Day4Stuff;

namespace AdventOfCode2020
{
    public static class Day4
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day4.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            PassportManager passMangager = new PassportManager(input);
            List<Passport> valid = passMangager.PassportValidation1();

            Console.WriteLine("Valid Passports: "+valid.Count);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            PassportManager passMangager = new PassportManager(input);
            List<Passport> valid = passMangager.PassportValidation2();

            Console.WriteLine("Valid Passports: " + valid.Count);
        }


    }
}