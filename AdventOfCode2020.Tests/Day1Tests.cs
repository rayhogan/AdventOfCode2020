using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        public void Day1Part1Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day1_example.txt");

            // Act
            int result = Day1.Calculate2Sum(input);

            // Assert
            Assert.AreEqual(514579, result);
        }
        [TestMethod]
        public void Day1Part2Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day1_example.txt");

            // Act
            int result = Day1.Calculate3Sum(input);

            // Assert
            Assert.AreEqual(241861950, result);
        }
    }
}
