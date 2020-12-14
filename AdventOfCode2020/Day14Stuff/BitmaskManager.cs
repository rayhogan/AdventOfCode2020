using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day14Stuff
{
    public class BitmaskManager
    {
        private List<BitmaskOperation> Operations = new List<BitmaskOperation>();
        private Dictionary<long, long> Memory = new Dictionary<long, long>();
        public BitmaskManager(string[] input)
        {
            ParseInput(input);
        }

        private void ParseInput(string[] input)
        {
            string mask = "";
            List<(int, int)> ops = new List<(int, int)>();
            foreach (string s in input)
            {


                var split = s.Replace(" ", "").Split('=');
                if (split[0] == "mask")
                {
                    if (mask != "")
                    {
                        Operations.Add(new BitmaskOperation(mask, ops));
                        mask = "";
                        ops = new List<(int, int)>();
                    }
                    mask = split[1];
                }
                else if (split[0].StartsWith("mem["))
                {
                    int memLoc = Convert.ToInt32(Regex.Replace(split[0], "[^0-9]", ""));
                    int value = Convert.ToInt32(split[1]);
                    ops.Add((memLoc, value));
                }
                else
                    throw new Exception("Unknown Operation");
            }

            Operations.Add(new BitmaskOperation(mask, ops));

        }

        public long SumMemoryValues()
        {
            foreach (BitmaskOperation bitOP in Operations)
            {
                foreach ((int, int) action in bitOP.Memory)
                {
                    // Convert value to binary
                    string binary = Convert.ToString(action.Item2, 2);

                    int stop = binary.Length;
                    for (int i = 0; i < 36 - stop; i++)
                    {
                        binary = "0" + binary;
                    }

                    // Apply mask
                    StringBuilder sb = new StringBuilder(binary);
                    var mask = bitOP.Mask.Select((i, n) => (n, i)).ToList();
                    List<(int, char)> filteredMask = mask.Where((i, n) => i.Item2 != 'X').ToList();
                    foreach ((int, char) m in filteredMask)
                    {
                        sb[m.Item1] = m.Item2;
                    }

                    // Convert back to decimal & save to memory
                    long output = Convert.ToInt64(sb.ToString(), 2);
                    Memory[action.Item1] = output;
                }
            }
            return Memory.Sum(x => x.Value);
        }

        public long SumMemoryValuesVersion2()
        {
            // Clear memory if it has anything
            Memory.Clear();

            foreach (BitmaskOperation bitOP in Operations)
            {
                foreach ((int, int) action in bitOP.Memory)
                {
                    // Convert value to binary
                    string binary = Convert.ToString(action.Item1, 2);

                    int stop = binary.Length;
                    for (int i = 0; i < 36 - stop; i++)
                    {
                        binary = "0" + binary;
                    }

                    // Swap the 1's
                    StringBuilder sb = new StringBuilder(binary);
                    var mask = bitOP.Mask.Select((i, n) => (n, i)).ToList();
                    List<(int, char)> ones = mask.Where((i, n) => i.Item2 == '1').ToList();

                    foreach ((int, char) m in ones)
                    {
                        sb[m.Item1] = m.Item2;
                    }

                    // Get a list of the permutations
                    mask = bitOP.Mask.Select((i, n) => (n, i)).ToList();
                    List<(int, char)> xlocations = mask.Where((i, n) => i.Item2 == 'X').ToList();
                    List<string> perms = new List<string>();
                    Generate(0, (xlocations.Count * -1), "", xlocations.Count, perms); //(Had to pass in negative number to get all perms)

                    // Loop through the permutations to get the addresses
                    foreach(string s in perms)
                    {
                        StringBuilder address = new StringBuilder(sb.ToString());
                        for (int i=0;i<s.Length;i++)
                        {
                            address[xlocations[i].Item1] = s[i];
                        }

                        // Convert and add it to memory
                        long output = Convert.ToInt64(address.ToString(), 2);
                        Memory[output] = action.Item2;
                    }
                    perms.Clear();
                }
            }
            return Memory.Sum(x => x.Value);
        }

        // This method is a modified version of: https://www.geeksforgeeks.org/generate-binary-permutations-1s-0s-every-point-permutations/
        public void Generate(int ones, int zeroes, String str, int len, List<string> values)
        {

            // If length of current string becomes same as desired length  
            if (len == str.Length)
            {
                values.Add(str);
                return;
            }

            // Append a 1 and recur  
            Generate(ones + 1, zeroes, str + "1", len, values);

            // If there are more 1's, append a 0 as well, and recur  
            if (ones > zeroes)
            {
                Generate(ones, zeroes + 1, str + "0", len, values);
            }

        }
    }

    public class BitmaskOperation
    {
        public string Mask;
        public List<(int, int)> Memory;
        public BitmaskOperation(string mask, List<(int, int)> memory)
        {
            Mask = mask;
            Memory = memory;
        }
    }


}
