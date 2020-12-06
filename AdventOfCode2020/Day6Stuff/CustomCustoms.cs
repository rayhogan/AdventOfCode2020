using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day6Stuff
{
    public static class CustomCustoms
    {
        public static int GetGroupAnswers(string[] input)
        {
            int count = 0;
            List<string> groupAnswers = new List<string>();
            foreach (string s in input)
            {
                if (s != string.Empty)
                {
                    groupAnswers.Add(s);
                }
                else
                {
                    count += groupAnswers.Select(e => e.ToArray()).Aggregate((a, b) => a.Union(b).ToArray()).Length;
                    groupAnswers.Clear();
                }
            }

            count += groupAnswers.Select(e => e.ToArray()).Aggregate((a, b) => a.Union(b).ToArray()).Length;
            return count;
        }

        public static int GetCommonGroupPositives(string[] input)
        {
            int count = 0;
            List<string> groupAnswers = new List<string>();
            foreach(string s in input)
            {
                if(s != string.Empty)
                {
                    groupAnswers.Add(s);
                }
                else
                {
                    count += groupAnswers.Select(e => e.ToArray()).Aggregate((a, b) => a.Intersect(b).ToArray()).Length;
                    groupAnswers.Clear();
                }
            }

            count += groupAnswers.Select(e => e.ToArray()).Aggregate((a, b) => a.Intersect(b).ToArray()).Length;
            return count;
        }
    }
}
