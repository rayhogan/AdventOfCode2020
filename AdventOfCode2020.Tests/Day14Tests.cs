using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day14Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day14Tests
    {

        [TestMethod]
        public void Day14Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day14_example.txt");

            //Act
            BitmaskManager bits = new BitmaskManager(input);
            long sum = bits.SumMemoryValues();


            //Assert
            Assert.AreEqual(165L, sum);

        }

        [TestMethod]
        public void Day14Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day14_example2.txt");

            //Act
            BitmaskManager bits = new BitmaskManager(input);
            long sum = bits.SumMemoryValuesVersion2();

            //Assert
            Assert.AreEqual(208L, sum);


        }

    }
}
