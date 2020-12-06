using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day6Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day6Tests
    {

        [TestMethod]
        public void Day6Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day6_example.txt");

            //Act
            int count = CustomCustoms.GetGroupAnswers(input);

            //Assert
            Assert.AreEqual(11, count);
        }

        [TestMethod]
        public void Day6Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day6_example.txt");

            //Act
            int count = CustomCustoms.GetCommonGroupPositives(input);

            //Assert
            Assert.AreEqual(6, count);
        }

    }
}
