using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day8Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day8Tests
    {

        [TestMethod]
        public void Day8Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day8_example.txt");

            //Act
            GameBoy gameBoy = new GameBoy(input);
            int accum = gameBoy.FindRepeatInstructions();

            //Assert
            Assert.AreEqual(5, accum);
        }

        [TestMethod]
        public void Day8Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day8_example.txt");

            //Act
            GameBoy gameBoy = new GameBoy(input);
            int accum = gameBoy.FixBootInstructions();

            //Assert
            Assert.AreEqual(8, accum);

        }

    }
}
