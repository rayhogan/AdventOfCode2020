using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day17Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day17Tests
    {

        [TestMethod]
        public void Day17Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day17_example.txt");
            SpaceMapper mapper = new SpaceMapper(input);

            //Act
            int result = mapper.CountActivePart1();

            //Assert
            Assert.AreEqual(112, result);

        }

        [TestMethod]
        public void Day17Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day17_example.txt");
            SpaceMapper mapper = new SpaceMapper(input);

            //Act
            int result = mapper.CountActivePart2();

            //Assert
            Assert.AreEqual(848, result);


        }

    }
}
