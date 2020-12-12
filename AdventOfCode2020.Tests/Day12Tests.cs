using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day12Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day12Tests
    {

        [TestMethod]
        public void Day12Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day12_example.txt");

            //Act
            ShipNavigator navi = new ShipNavigator(input);
            int result = navi.Part1Distance();

            //Assert
            Assert.AreEqual(25, result);
 
        }

        [TestMethod]
        public void Day12Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day12_example.txt");

            //Act
            ShipNavigator navi = new ShipNavigator(input);
            int result = navi.Part2Distance();

            //Assert
            Assert.AreEqual(286, result);


        }

    }
}
