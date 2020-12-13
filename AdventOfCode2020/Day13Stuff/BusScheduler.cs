using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day13Stuff
{
    public class BusScheduler
    {
        private int Time = 0;
        private List<int> BusNumbers = new List<int>();
        private List<int> DepartureOrder = new List<int>();
        public BusScheduler(string[] input)
        {
            Time = Int32.Parse(input[0]);
            var split = input[1].Split(',');
            BusNumbers = split.Where(i => i != "x").Select(i => Int32.Parse(i)).ToList();

            for (int i = 0; i < split.Length; i++)
            {
                if (split[i] != "x")
                {
                    DepartureOrder.Add(i);
                }
            }
        }

        public int CalculateWaitingTime()
        {
            List<int> waitingTimes = BusNumbers.Select(i => i * (Math.Floor((double)(Time / i)) + 1)).Select(i => Convert.ToInt32(i)).Select(i => i - Time).ToList();

            int waitTime = waitingTimes.Min();
            int busNumber = BusNumbers[waitingTimes.IndexOf(waitTime)];

            return waitTime * busNumber;
        }

        public long CalculateSynchronicity()
        {
            long startPoint = 0;
            long increment = BusNumbers[0];
            for (int i = 1; i < BusNumbers.Count; i++)
            {
                while ((startPoint + DepartureOrder[i]) % BusNumbers[i] != 0)
                {
                    startPoint += increment;
                }

                increment *= BusNumbers[i];
            }
            return startPoint;
        }
    }
}
