using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day7Stuff
{
    public class Bag
    {
        public string Name { get; set; }
        public Dictionary<String, int> Children { get; set; }
        public Bag(string name)
        {
            Name = name;
            Children = new Dictionary<String, int>();
        }
    }
}
