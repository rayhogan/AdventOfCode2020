using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2020;
using AdventOfCode2020.Day2Stuff;
using System.Collections.Generic;

namespace AdventOfCode2020.Tests
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        public void Day2Part1Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day2_example.txt");

            // Act
            PasswordManager pwdmgr = new PasswordManager(input);
            List<Password> output = pwdmgr.PasswordPolicyViolation1();

            // Assert
            Assert.AreEqual(1, output.Count);
            Assert.AreEqual("cdefg", output[0].UserPassword);

        }
        [TestMethod]
        public void Day2Part2Test()
        {
            // Arrange
            string[] input = Helper.ParseInput(@"Inputs\\Day2_example.txt");

            // Act
            PasswordManager pwdmgr = new PasswordManager(input);
            List<Password> output = pwdmgr.PasswordPolicyViolation2();

            // Assert
            Assert.AreEqual(2, output.Count);
            Assert.AreEqual("cdefg", output[0].UserPassword);
            Assert.AreEqual("ccccccccc", output[1].UserPassword);

        }
    }
}
