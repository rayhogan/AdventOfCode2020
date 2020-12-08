
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day8Stuff
{
    public class GameBoy
    {
        private List<(string, int)> BootCode = new List<(string, int)>();
        public GameBoy(string[] input)
        {
            BuildBootLoader(input);
        }

        private void BuildBootLoader(string[] input)
        {
            BootCode = input.Select(l => l.Split(' ')).Select(l => (Instructions: l[0], Value: int.Parse(l[1]))).ToList();
        }

        public int FindRepeatInstructions()
        {
            return RunLoader(BootCode).Item2;
        }

        private (bool, int) RunLoader(List<(string, int)> input)
        {
            int accumulator = 0;
            int index = 0;

            var spentInstructions = new bool[input.Count];

            while (index != input.Count && !spentInstructions[index])
            {
                spentInstructions[index] = true;

                if (input[index].Item1 == "nop")
                {
                    index++;
                }
                else if (input[index].Item1 == "acc")
                {
                    accumulator += input[index].Item2;
                    index++;
                }
                else if (input[index].Item1 == "jmp")
                {
                    index += input[index].Item2;
                }
                else
                {
                    throw new Exception("Unknown Instruction");
                }
            }

            return (index == input.Count, accumulator);
        }

        public int FixBootInstructions()
        {
            for (int i = 0; i < BootCode.Count; i++)
            {
                if (BootCode[i].Item1 != "acc")
                {
                    var original = BootCode[i];
                    var replacement = (BootCode[i].Item1 == "jmp" ? "nop" : "jmp", BootCode[i].Item2);
                    BootCode[i] = replacement;
                    var result = RunLoader(BootCode);
                    if(result.Item1)
                    {
                        return result.Item2;
                    }
                    else
                    {
                        BootCode[i] = original;
                    }
                }
            }

            return 0;
        }
    }
}
