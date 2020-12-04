using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day4Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day4Tests
    {

        [TestMethod]
        public void Day4BuildPassports()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day4_example.txt");

            // Act
            PassportManager passMangager = new PassportManager(input);
            int passportCount = passMangager.passports.Count;

            // Assert
            Assert.AreEqual(4, passportCount);
        }
        [TestMethod]
        public void Day4Part1Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day4_example.txt");

            // Act
            PassportManager passMangager = new PassportManager(input);
            List<Passport> valid = passMangager.PassportValidation1();

            // Assert
            Assert.AreEqual(2, valid.Count);

        }
        [TestMethod]
        public void Day4Part2Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day4_example2_valid.txt");


            // Act
            PassportManager passMangager = new PassportManager(input);
            List<Passport> valid = passMangager.PassportValidation2();

            // Assert
            Assert.AreEqual(4, valid.Count);


        }
    }
}
