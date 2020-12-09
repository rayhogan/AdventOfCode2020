using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public static class Helper
    {
        public static string[] ParseInput(string location)
        {
            string[] input = System.IO.File.ReadAllLines(location);
            return input;
        }

        public static void PrintChallenge(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintChallengePart(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
