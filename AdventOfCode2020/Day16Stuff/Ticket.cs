using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day16Stuff
{
    public class Ticket
    {
        public List<int> TicketValues = new List<int>();
        public Ticket(string input)
        {
            foreach(string s in input.Split(','))
            {
                TicketValues.Add(Convert.ToInt32(s));
            }
        }
    }
}
