using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day4Stuff
{
    public class Passport
    {
        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public int CountryID { get; set; }

        public Passport(int birthYear, int issueYear, int expirationYear, string height, string hairColor, string eyeColor, string passportID, int countryID)
        {
            BirthYear = birthYear;
            ExpirationYear = expirationYear;
            IssueYear = issueYear;
            Height = height;
            HairColor = hairColor;
            EyeColor = eyeColor;
            PassportID = passportID;
            CountryID = countryID;

        }

        public Passport()
        {
            BirthYear = 0;
            ExpirationYear = 0;
            IssueYear = 0;
            Height = "";
            HairColor = "";
            EyeColor = "";
            PassportID = "";
            CountryID = 0;
        }

        public void ClearFields()
        {
            BirthYear = 0;
            ExpirationYear = 0;
            IssueYear = 0;
            Height = "";
            HairColor = "";
            EyeColor = "";
            PassportID = "";
            CountryID = 0;
        }
    }
}
