using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day5Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day5Tests
    {

        [TestMethod]
        public void Day5Part1Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day5_example.txt");

            // Act
            AeroplaneManager aero = new AeroplaneManager(input);
            int highestID = aero.HighestSeatID();

            // Assert
            Assert.AreEqual(820, highestID);

        }
        [TestMethod]
        public void Day5PositionRowFinderTests()
        {

            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day5_example.txt");
            
            string rowTest1 = "BFFFBBF";
            string rowTest2 = "FFFBBBF";
            string rowTest3 = "BBFFBBF";

            AeroplaneManager aero = new AeroplaneManager(input);
            //Act
            int result1 = aero.FindPosition(rowTest1, 0, 127);
            int result2 = aero.FindPosition(rowTest2, 0, 127);
            int result3 = aero.FindPosition(rowTest3, 0, 127);

            //Assert
            Assert.AreEqual(70, result1);
            Assert.AreEqual(14, result2);
            Assert.AreEqual(102, result3);
        }

        [TestMethod]
        public void Day5PositionColumnFinderTests()
        {

            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day5_example.txt");

            string colTest1 = "RRR";
            string colTest2 = "RLL";
            string colTest3 = "RLR";

            AeroplaneManager aero = new AeroplaneManager(input);
            //Act
            int result1 = aero.FindPosition(colTest1, 0, 7);
            int result2 = aero.FindPosition(colTest2, 0, 7);
            int result3 = aero.FindPosition(colTest3, 0, 7);

            //Assert
            Assert.AreEqual(7, result1);
            Assert.AreEqual(4, result2);
            Assert.AreEqual(5, result3);


        }
    }
}
