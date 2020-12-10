using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day10Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day10Tests
    {

        [TestMethod]
        public void Day10Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day10_example.txt");

            //Act
            VoltageAdaptor volts = new VoltageAdaptor(input);
            int result = volts.CalculateDifferences();

            //Assert
            Assert.AreEqual(35, result);
 
        }
        [TestMethod]
        public void Day10Part1Bonus()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day10_exampleBonus.txt");

            //Act
            VoltageAdaptor volts = new VoltageAdaptor(input);
            int result = volts.CalculateDifferences();

            //Assert
            Assert.AreEqual(220, result);

        }

        [TestMethod]
        public void Day10Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day10_example.txt");

            //Act
            VoltageAdaptor volts = new VoltageAdaptor(input);
            ulong result = volts.CalculateCombinations();

            //Assert
            Assert.AreEqual((ulong)8, result);


        }

    }
}
