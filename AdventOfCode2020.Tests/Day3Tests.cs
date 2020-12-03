using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day3Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void Day3Part1Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day3_example.txt");

            // Act
            TobogganSatNav satSav = new TobogganSatNav(input);
            int treeCount = satSav.RoutePlanner(3, 1);

            // Assert
            Assert.AreEqual(7, treeCount);

        }
        [TestMethod]
        public void Day3Part2Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day3_example.txt");

            // Act
            int treeCount = 1;
            TobogganSatNav satSav = new TobogganSatNav(input);
            treeCount = treeCount * satSav.RoutePlanner(1, 1);
            treeCount = treeCount * satSav.RoutePlanner(3, 1);
            treeCount = treeCount * satSav.RoutePlanner(5, 1);
            treeCount = treeCount * satSav.RoutePlanner(7, 1);
            treeCount = treeCount * satSav.RoutePlanner(1, 2);

            // Assert
            Assert.AreEqual(336, treeCount);

        }
    }
}
