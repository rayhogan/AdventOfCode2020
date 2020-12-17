using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day16Stuff
{
    public class TicketTranslator
    {
        private List<Rule> Rules = new List<Rule>();
        private List<Ticket> Tickets = new List<Ticket>();
        private Ticket MyTicket;
        public TicketTranslator(string[] input)
        {
            // Used to jump around
            int skip = 0;

            // Parse validation rules
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != string.Empty)
                {
                    Rules.Add(new Rule(input[i]));
                }
                else
                {
                    skip = i + 2;
                    break;
                }
            }

            // Parse mine very own ticket!!
            MyTicket = new Ticket(input[skip]);

            skip += 3;
            for (int i = skip; i < input.Length; i++)
            {
                Tickets.Add(new Ticket(input[i]));
            }
            int h = 0;
        }

        public int ErrorRate()
        {
            int output = 0;

            foreach (Ticket ticket in Tickets)
            {
                foreach (int i in ticket.TicketValues)
                {
                    int count = 0;
                    foreach (Rule rule in Rules)
                    {
                        if (rule.Validate(i))
                            count++;
                    }

                    if (count == 0)
                        output += i;
                }
            }

            return output;
        }

        public long MultiplyTicketProperty(string property)
        {
            RemoveInvalid();

            long result = 1L;

            List<List<string>> ruleOrder = new List<List<string>>(); // Prop, Rule

            for (int i = 0; i < Tickets.First().TicketValues.Count; i++) // For every ticket property
            {
                List<string> validRules = new List<string>();
                for (int k = 0; k < Rules.Count; k++) // For every rule
                {
                    int count = 0;
                    for (int j = 0; j < Tickets.Count; j++) // For every ticket
                    {
                        if (Rules[k].Validate(Tickets[j].TicketValues[i])) // Check the same property of all tickets against all rules
                            count++;
                    }
                    if (count == Tickets.Count)
                        validRules.Add(Rules[k].Name);
                }
                ruleOrder.Add(validRules);
            }

            // Trim the valid rules
            bool trimming = true;
            while (trimming)
            {
                for (int i = 0; i < ruleOrder.Count; i++)
                {
                    if (ruleOrder[i].Count == 1)
                    {
                        for (int j = 0; j < ruleOrder.Count; j++)
                        {
                            if (i != j)
                                ruleOrder[j].Remove(ruleOrder[i][0]);

                        }
                    }
                }

                int count = 0;
                for (int i = 0; i < ruleOrder.Count; i++)
                {
                    count += ruleOrder[i].Count;
                }
                if (count == ruleOrder.Count)
                    trimming = false;
            }

            for (int i = 0; i < ruleOrder.Count; i++)
            {
                if (ruleOrder[i][0].StartsWith(property))
                    result *= MyTicket.TicketValues[i];
            }

            return result;
        }

        private void RemoveInvalid()
        {
            List<Ticket> remove = new List<Ticket>();

            foreach (Ticket ticket in Tickets)
            {
                foreach (int i in ticket.TicketValues)
                {
                    int count = 0;
                    foreach (Rule rule in Rules)
                    {
                        if (rule.Validate(i))
                            count++;
                    }

                    if (count == 0)
                    {
                        remove.Add(ticket);
                        break;
                    }
                }
            }

            foreach (Ticket t in remove)
            {
                Tickets.Remove(t);
            }

        }
    }
}
