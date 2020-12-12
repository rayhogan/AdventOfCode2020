using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day11Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day11Tests
    {

        [TestMethod]
        public void Day11Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day11_example.txt");

            //Act
            SeatSorter seatSorter = new SeatSorter(input);

            int seatCount = seatSorter.PartOne();

            //Assert
            Assert.AreEqual(37, seatCount);
 
        }

        [TestMethod]
        public void Day11Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day11_example.txt");

            //Act
            SeatSorter seatSorter = new SeatSorter(input);
            int seatCount = seatSorter.PartTwo();

            //Assert
            Assert.AreEqual(26, seatCount);


        }

    }
}
