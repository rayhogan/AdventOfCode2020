using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day16Stuff
{
    public class Rule
    {
        public List<(int, int)> Rules = new List<(int, int)>();
        public string Name = "";
        public Rule(string input)
        {
            //departure location: 34-269 or 286-964

            input = input.Replace("or", "|").Replace(" ", "");
            string[] split = input.Split(':');
            Name = split[0];
            split = split[1].Split('|');

            string[] ruleOne = split[0].Split('-');
            string[] ruleTwo = split[1].Split('-');
            Rules.Add((Convert.ToInt32(ruleOne[0]), (Convert.ToInt32(ruleOne[1]))));
            Rules.Add((Convert.ToInt32(ruleTwo[0]), (Convert.ToInt32(ruleTwo[1]))));

        }

        public bool Validate(int input)
        {
            foreach((int, int) rule in Rules)
            {
                if (input >= rule.Item1 && input <= rule.Item2)
                    return true;
            }

            return false;
        }
    }
}
