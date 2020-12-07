using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day7Stuff
{
    public class BaggageProcessor
    {
        private List<Bag> Bags = new List<Bag>();
        public BaggageProcessor(string[] input)
        {
            Bags = BuildBagRules(input);
        }

        public List<Bag> FindOuterParentBags(string bagColor)
        {
            List<Bag> containsColor = Bags.Where(b => b.Children.ContainsKey(bagColor)).ToList();

            return containsColor.Concat(containsColor.SelectMany(b => FindOuterParentBags(b.Name))).Distinct().ToList();
        }

        public int CountInnerBags(string bagColor)
        {
            return RecursiveCount(bagColor) - 1;
        }

        private int RecursiveCount(string bagColor)
        {
            int count = 1;
            Bag bag = Bags.Where(b => b.Name == bagColor).First();

            foreach (var s in bag.Children)
            {
                count += s.Value * RecursiveCount(s.Key);

            }
            return count;
        }


        public List<Bag> BuildBagRules(string[] input) // Bilbo Bagrules :)
        {
            List<Bag> output = new List<Bag>();

            foreach (string s in input)
            {
                string clean = s.Replace(" bags", string.Empty).Replace(" bag", string.Empty).Replace(".", string.Empty);
                string[] split = clean.Split("contain");
                string name = split[0].Trim();

                Bag bag = new Bag(name);


                if (split[1].Contains(","))
                {
                    string[] split2 = split[1].Split(',');
                    foreach (string bags in split2)
                    {
                        string[] split3 = bags.TrimStart().Split(' ');
                        name = split3[1] + " " + split3[2];
                        bag.Children.Add(name.Trim(), Int32.Parse(split3[0]));
                    }
                }
                else
                {
                    if (!split[1].Contains("no other")) // Contains 1 bag
                    {
                        string[] split2 = split[1].TrimStart().Split(' ');
                        name = split2[1] + " " + split2[2];

                        bag.Children.Add(name.Trim(), Int32.Parse(split2[0]));

                    }
                }

                output.Add(bag);
            }
            return output;
        }

    }
}
