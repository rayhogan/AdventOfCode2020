using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020.Day5Stuff
{
    public class AeroplaneManager
    {
        private Dictionary<(int, int), int> Seats;
        public AeroplaneManager(string[] input)
        {
            Seats = new Dictionary<(int x, int y), int>();
            CreateSeatPlan(input);
        }

        private void CreateSeatPlan(string[] input)
        {
            for (int i = 0; i <= 127; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Seats.Add((i, j), 0);
                }
            }

            foreach (string s in input)
            {
                int row = FindPosition(s.Substring(0, 7), 0, 127);
                int column = FindPosition(s.Substring(7, 3), 0, 7);
                int seatID = (row * 8) + column;
                Seats[(row, column)] = seatID;
            }
        }

        public int HighestSeatID()
        {
            return Seats.Values.Max();
        }

        public int FindMySeat()
        {
            for (int i = 1; i <= 127; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (Seats[(i, j)] == 0 && Seats[(i - 1, j)] != 0 && Seats[(i + 1, j)] != 0)
                        return i * 8 + j;
                }
            }
            return 0;
        }

        public int FindPosition(string data, int min, int max)
        {
            double row = 0;
            double minRow = min;
            double maxRow = max;

            char[] inputData = data.ToCharArray();

            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i] == 'F' || inputData[i] == 'L')
                {
                    row = Math.Floor((maxRow - minRow) / 2) + minRow;
                    maxRow = row;

                }
                else if (inputData[i] == 'B' || inputData[i] == 'R')
                {
                    row = Math.Floor(((maxRow - minRow) / 2) + minRow) + 1;
                    minRow = row;
                }
                else
                {
                    throw new Exception("Invalid instruction");
                }
            }
            return (int)row;
        }
    }
}
