using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day2Stuff
{
    public class PasswordManager
    {
        public List<Password> Passwords = new List<Password>();
        public PasswordManager(string[] inputfile)
        {
            ParsePasswordFile(inputfile);
        }

        private void ParsePasswordFile(string[] inputFile)
        {
            foreach (string s in inputFile)
            {
                string[] splitLine = s.Split(' ');
                int minValue = Int32.Parse(splitLine[0].Split('-')[0]);
                int maxValue = Int32.Parse(splitLine[0].Split('-')[1]);

                char character = splitLine[1].ToCharArray()[0];

                string password = splitLine[2];

                Passwords.Add(new Password(minValue, maxValue, character, password));
            }
        }

        public List<Password> PasswordPolicyViolation1()
        {
            List<Password> output = new List<Password>();
            foreach (Password pass in Passwords)
            {
                int count = pass.UserPassword.Count(f => f == pass.Character);

                if (count < pass.Value1 || count > pass.Value2)
                    output.Add(pass);

            }

            return output;
        }

        public List<Password> PasswordPolicyViolation2()
        {
            List<Password> output = new List<Password>();

            foreach (Password pass in Passwords)
            {
                char[] password = pass.UserPassword.ToCharArray();

                bool firstPosition = ValidateCharacter(password, pass.Value1, pass.Character);
                bool secondPosition = ValidateCharacter(password, pass.Value2, pass.Character);

                if ((firstPosition && secondPosition) || (!firstPosition && !secondPosition))
                {
                    output.Add(pass);
                }


            }
            return output;
        }

        private bool ValidateCharacter(char[] password, int position, char character)
        {
            if (position > password.Length)
                return false;
            else
            {
                if (password[position - 1] == character)
                    return true;
                else
                    return false;
            }
        }
    }
}
