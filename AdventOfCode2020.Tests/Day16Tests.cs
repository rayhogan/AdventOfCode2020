using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day16Stuff;
using System.Linq;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day16Tests
    {

        [TestMethod]
        public void Day16Part1()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day16_example.txt");
            TicketTranslator ticketJobby = new TicketTranslator(input);

            //Act
            int result = ticketJobby.ErrorRate();

            //Assert
            Assert.AreEqual(71, result);

        }

        [TestMethod]
        public void Day16Part2()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day16_example2.txt");
            TicketTranslator ticketJobby = new TicketTranslator(input);

            //Act
            long result = ticketJobby.MultiplyTicketProperty("seat");

            //Assert
            Assert.AreEqual(13, 13);

        }

    }
}
