using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day9Stuff;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day9Tests
    {

        [TestMethod]
        public void Day9Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day9_example.txt");

            //Act
            XmasSystem xmas = new XmasSystem(input);
            long result = xmas.FindInvalidData(5);

            //Assert
            Assert.AreEqual(127, result);
 
        }

        [TestMethod]
        public void Day9Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day9_example.txt");

            //Act
            XmasSystem xmas = new XmasSystem(input);
            long result = xmas.FindInvalidData(5);
            long sum = xmas.FindContiguousSet(result);

            //Assert
            Assert.AreEqual(62, sum);


        }

    }
}
