using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4Stuff
{
    public class PassportManager
    {
        public List<Passport> passports = new List<Passport>();

        public PassportManager(string[] input)
        {
            BuildPassports(input);
        }

        private void BuildPassports(string[] input)
        {
            List<string> removedSpaces = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {

                if (input[i] != string.Empty)
                {
                    sb.Append(input[i] + " ");
                }
                else
                {
                    removedSpaces.Add(sb.ToString());
                    sb.Clear();
                }
            }

            removedSpaces.Add(sb.ToString());

            Passport pass = new Passport();
            foreach (string s in removedSpaces)
            {
                string[] split = s.Split(' ');
                foreach (string splitString in split)
                {
                    if (splitString != string.Empty)
                    {
                        switch (splitString.Split(':')[0])
                        {
                            case "byr":
                                pass.BirthYear = Int32.Parse(splitString.Split(':')[1]);
                                break;
                            case "iyr":
                                pass.IssueYear = Int32.Parse(splitString.Split(':')[1]);
                                break;
                            case "eyr":
                                pass.ExpirationYear = Int32.Parse(splitString.Split(':')[1]);
                                break;
                            case "hgt":
                                pass.Height = splitString.Split(':')[1];
                                break;
                            case "hcl":
                                pass.HairColor = splitString.Split(':')[1];
                                break;
                            case "ecl":
                                pass.EyeColor = splitString.Split(':')[1];
                                break;
                            case "pid":
                                pass.PassportID = splitString.Split(':')[1];
                                break;
                            case "cid":
                                pass.CountryID = Int32.Parse(splitString.Split(':')[1]);
                                break;
                            default:
                                throw new Exception("Invalid Passport Character Found: " + splitString.Split(':')[0]);
                        }
                    }
                }
                passports.Add(new Passport(pass.BirthYear, pass.IssueYear, pass.ExpirationYear, pass.Height, pass.HairColor, pass.EyeColor, pass.PassportID, pass.CountryID));
                pass.ClearFields();
            }
        }

        public List<Passport> PassportValidation1()
        {
            List<Passport> output = new List<Passport>();
            foreach (Passport p in passports)
            {
                bool passportValid = true;

                foreach (PropertyInfo prop in p.GetType().GetProperties())
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (type == typeof(string))
                    {

                        if (prop.GetValue(p, null).ToString() == string.Empty)
                            passportValid = false;


                    }
                    else if (type == typeof(int))
                    {
                        if (prop.Name != "CountryID")
                        {

                            if ((int)prop.GetValue(p, null) == 0)
                                passportValid = false;
                        }
                    }
                    else
                    {
                        throw new Exception("Unknown property type on Passport");
                    }
                }

                if (passportValid)
                {
                    output.Add(p);
                }
            }

            return output;
        }

        public List<Passport> PassportValidation2()
        {
            List<Passport> output = new List<Passport>();

            List<Passport> firstValidation = PassportValidation1();

            foreach (Passport p in firstValidation)
            {
                bool passportValid = true;

                // Validate the years
                if (p.BirthYear < 1920 || p.BirthYear > 2002)
                {
                    passportValid = false;
                }

                if (p.IssueYear < 2010 || p.IssueYear > 2020)
                {
                    passportValid = false;
                }

                if (p.ExpirationYear < 2020 || p.ExpirationYear > 2030)
                {
                    passportValid = false;
                }

                // Validate height
                int result = Convert.ToInt32(Regex.Replace(p.Height, "[^0-9]", ""));
                if (p.Height.EndsWith("cm"))
                {
                    if (result < 150 || result > 193)
                        passportValid = false;
                }
                else if (p.Height.EndsWith("in"))
                {
                    if (result < 59 || result > 76)
                        passportValid = false;
                }
                else
                {
                    passportValid = false;
                }

                // Validate hair color
                if (!p.HairColor.StartsWith("#") || p.HairColor.Length != 7)
                    passportValid = false;
                else
                {
                    int illegalChars = Regex.Matches(p.HairColor, @"[g-zG-Z]").Count;
                    if (illegalChars > 0)
                        passportValid = false;
                }

                // Validate eye color
                if (p.EyeColor != "amb" && p.EyeColor != "blu" && p.EyeColor != "brn" && p.EyeColor != "gry" && p.EyeColor != "grn" && p.EyeColor != "hzl" && p.EyeColor != "oth")
                    passportValid = false;

                // Validate passport ID is 9 digits only
                bool allIntegers = IsDigitsOnly(p.PassportID);
                if (!allIntegers || p.PassportID.Length != 9)
                {
                    passportValid = false;
                }

                if (passportValid)
                {
                    output.Add(p);
                }
            }

            return output;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}

