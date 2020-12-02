using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day1Stuff
{
    public class Password
    {
        public int Value1 { get; }
        public int Value2 { get; }
        public char Character { get; }
        public string UserPassword { get; }
        public Password(int minCount, int maxCount, char character, string password)
        {
            Value1 = minCount;
            Value2 = maxCount;
            Character = character;
            UserPassword = password;

        }
    }
}
