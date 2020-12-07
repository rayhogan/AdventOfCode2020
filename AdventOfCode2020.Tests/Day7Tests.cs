using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day7Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day7Tests
    {

        [TestMethod]
        public void Day7Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day7_example.txt");

            //Act
            BaggageProcessor processor = new BaggageProcessor(input);
            List<Bag> parentBags = processor.FindOuterParentBags("shiny gold");

            //Assert
            Assert.AreEqual(4, parentBags.Count);
        }

        [TestMethod]
        public void Day7Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day7_example.txt");

            //Act
            BaggageProcessor processor = new BaggageProcessor(input);
            int count = processor.CountInnerBags("shiny gold");

            //Assert
            Assert.AreEqual(32, count);

        }
        [TestMethod]
        public void Day7Part2Bonus()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day7_exampleBonus.txt");

            //Act
            BaggageProcessor processor = new BaggageProcessor(input);
            int count = processor.CountInnerBags("shiny gold");

            //Assert
            Assert.AreEqual(126, count);

        }
    }
}
