using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AdventOfCode2020.Day3Stuff
{
    public class TobogganSatNav
    {
        private Dictionary<(int, int), char> Map;
        private int mapHeight = 0;
        private int mapWidth = 0;
        public TobogganSatNav(string[] input)
        {
            Map = new Dictionary<(int x, int y), char>();
            BuildMap(input);
        }

        private void BuildMap(string[] input)
        {
            int y = 0;
            foreach (string s in input)
            {

                char[] mapLine = s.ToCharArray();
                for (int i = 0; i < mapLine.Length; i++)
                {
                    Map.Add((y, i), mapLine[i]);
                }
                y++;

            }

            mapHeight = input.Length;
            mapWidth = input[0].Length;
        }

        /// <summary>
        /// Passing in a turning algorithm, calculate how many trees you'd hit
        /// </summary>
        /// <returns>Number of hit trees</returns>
        public int RoutePlanner(int right, int down)
        {
            // Starting positions
            int x = 0;
            int y = 0;

            int treeCount = 0;

            while (y < mapHeight)
            {
                if (Map[(y, x)] == '#')
                {
                    
                    treeCount++;
                }

                x +=right;
                y += down;

                if (x > (mapWidth-1))
                {
                    x -= mapWidth;
                }
            }
            return treeCount;
        }
    }
}
