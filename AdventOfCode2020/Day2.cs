using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2020.Day1Stuff;

namespace AdventOfCode2020
{
    public static class Day2
    {
        public static void Run()
        {
            string[] input = Helper.ParseInput(@"Inputs\\Day2.txt");
            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");
            PasswordManager passwordManager = new PasswordManager(input);

            List<Password> invalidPasswords = passwordManager.PasswordPolicyViolation1();

            Console.WriteLine("Valid Passwords: " + (passwordManager.Passwords.Count - invalidPasswords.Count));

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            PasswordManager passwordManager = new PasswordManager(input);

            List<Password> invalidPasswords = passwordManager.PasswordPolicyViolation2();

            Console.WriteLine("Valid Passwords: " + (passwordManager.Passwords.Count - invalidPasswords.Count));
        }


    }
}