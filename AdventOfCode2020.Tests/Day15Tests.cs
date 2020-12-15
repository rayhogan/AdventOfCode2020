using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day15Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day15Tests
    {

        [TestMethod]
        public void Day15Part1()
        {
            // Arrange
            var input = new[] { 0, 3, 6 };

            //Act
            ElvishMemory elfGame = new ElvishMemory(input);
            long result = elfGame.FindSpokenNumber(2020);

            //Assert
            Assert.AreEqual(436, result);

        }

        [TestMethod]
        public void Day15Part1Bonus()
        {
            // Arrange
            var input1 = new[] { 1, 3, 2 };
            var input2 = new[] { 2, 1, 3 };
            var input3 = new[] { 1, 2, 3 };
            var input4 = new[] { 2, 3, 1 };
            var input5 = new[] { 3, 2, 1 };
            var input6 = new[] { 3, 1, 2 };

            //Act
            ElvishMemory elfGame1 = new ElvishMemory(input1);
            long result1 = elfGame1.FindSpokenNumber(2020);

            ElvishMemory elfGame2 = new ElvishMemory(input2);
            long result2 = elfGame2.FindSpokenNumber(2020);

            ElvishMemory elfGame3 = new ElvishMemory(input3);
            long result3 = elfGame3.FindSpokenNumber(2020);

            ElvishMemory elfGame4 = new ElvishMemory(input4);
            long result4 = elfGame4.FindSpokenNumber(2020);

            ElvishMemory elfGame5 = new ElvishMemory(input5);
            long result5 = elfGame5.FindSpokenNumber(2020);

            ElvishMemory elfGame6 = new ElvishMemory(input6);
            long result6 = elfGame6.FindSpokenNumber(2020);

            //Assert
            Assert.AreEqual(1, result1);
            Assert.AreEqual(10, result2);
            Assert.AreEqual(27, result3);
            Assert.AreEqual(78, result4);
            Assert.AreEqual(438, result5);
            Assert.AreEqual(1836, result6);

        }

        [TestMethod]
        public void Day15Part2()
        {
            // Arrange
            var input = new[] { 0, 3, 6 };

            //Act
            ElvishMemory elfGame = new ElvishMemory(input);
            long result = elfGame.FindSpokenNumber(30000000);

            //Assert
            Assert.AreEqual(175594, result);



        }

    }
}
