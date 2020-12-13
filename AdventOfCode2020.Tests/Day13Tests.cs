using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day13Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day13Tests
    {

        [TestMethod]
        public void Day13Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day13_example.txt");

            //Act
            BusScheduler bus = new BusScheduler(input);
            int result = bus.CalculateWaitingTime();

            //Assert
            Assert.AreEqual(295, result);
 
        }

        [TestMethod]
        public void Day13Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day13_example.txt");

            //Act
            BusScheduler bus = new BusScheduler(input);
            long result = bus.CalculateSynchronicity();

            //Assert
            Assert.AreEqual((long)1068781, result);


        }

    }
}
