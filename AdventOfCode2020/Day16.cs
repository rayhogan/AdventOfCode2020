using System;
using System.Collections.Generic;
using AdventOfCode2020.Day16Stuff;

namespace AdventOfCode2020
{
    public static class Day16
    {
        public static void Run()
        {

            string[] input = Helper.ParseInput(@"Inputs\\Day16.txt");

            Part1(input);
            Part2(input);
        }

        public static void Part1(string[] input)
        {
            Helper.PrintChallengePart("Part 1");

            TicketTranslator ticketJobby = new TicketTranslator(input);

            int result = ticketJobby.ErrorRate();

            Console.WriteLine("Invalid Tickets: " + result);

        }

        public static void Part2(string[] input)
        {
            Helper.PrintChallengePart("Part 2");

            TicketTranslator ticketJobby = new TicketTranslator(input);

            long result = ticketJobby.MultiplyTicketProperty("departure");

            Console.WriteLine("Your Value: " + result);

        }

    }
}
