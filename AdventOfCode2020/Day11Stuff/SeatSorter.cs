using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day11Stuff
{
    public class SeatSorter
    {
        private char[,] SeatMap;
        public SeatSorter(string[] input)
        {
            SeatMap = new char[input.Length + 2, input[0].Length + 2];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    SeatMap[i + 1, j + 1] = input[i][j];
                }
            }
        }

        public int PartOne()
        {
            bool peopleMoved = false;
            do
            {
                char[,] copy = CopyArray();
                peopleMoved = false;
                for (int i = 0; i < SeatMap.GetLength(0); i++)
                {
                    for (int j = 0; j < SeatMap.GetLength(1); j++)
                    {
                        if (SeatMap[i, j] == 'L')
                        {
                            if (SeatMap[i + 1, j] != '#' && SeatMap[i + 1, j + 1] != '#' && SeatMap[i + 1, j - 1] != '#' && SeatMap[i - 1, j] != '#' && SeatMap[i - 1, j - 1] != '#' && SeatMap[i - 1, j + 1] != '#' && SeatMap[i, j + 1] != '#' && SeatMap[i, j - 1] != '#')
                            {
                                copy[i, j] = '#';
                                peopleMoved = true;
                            }
                        }
                        else if (SeatMap[i, j] == '#')
                        {
                            int count = 0;
                            if (SeatMap[i + 1, j] == '#')
                                count++;

                            if (SeatMap[i + 1, j + 1] == '#')
                                count++;

                            if (SeatMap[i + 1, j - 1] == '#')
                                count++;

                            if (SeatMap[i - 1, j] == '#')
                                count++;

                            if (SeatMap[i - 1, j + 1] == '#')
                                count++;

                            if (SeatMap[i - 1, j - 1] == '#')
                                count++;

                            if (SeatMap[i, j + 1] == '#')
                                count++;

                            if (SeatMap[i, j - 1] == '#')
                                count++;

                            if (count >= 4)
                            {
                                copy[i, j] = 'L';
                                peopleMoved = true;
                            }
                        }
                    }
                }

                SeatMap = copy;
            }
            while (peopleMoved);

            //PrintSeatPlan();

            return CountOccupied();
        }

        public int PartTwo()
        {
            bool peopleMoved = false;
            do
            {
                char[,] copy = CopyArray();
                peopleMoved = false;
                for (int i = 0; i < SeatMap.GetLength(0); i++)
                {
                    for (int j = 0; j < SeatMap.GetLength(1); j++)
                    {
                        if (SeatMap[i, j] == 'L')
                        {
                            if (!CheckOccupied(i, j))
                            {
                                copy[i, j] = '#';
                                peopleMoved = true;
                            }
                        }
                        else if (SeatMap[i, j] == '#')
                        {
                            int count = CountOccupied(i, j);

                            if (count >= 5)
                            {
                                copy[i, j] = 'L';
                                peopleMoved = true;
                            }
                        }
                    }
                }

                SeatMap = copy;
                //PrintSeatPlan();
            }
            while (peopleMoved);



            return CountOccupied();
        }

        private bool CheckOccupied(int x, int y)
        {
            // Check their right
            for (int i = y + 1; i < SeatMap.GetLength(1); i++)
            {
                if (i < SeatMap.GetLength(1))
                {
                    if (SeatMap[x, i] == '#') // Seat is occupied, don't sit there
                    {
                        return true;
                    }
                    else if (SeatMap[x, i] == 'L') // Seat is free
                    {
                        break;
                    }
                }
            }

            // Check their left
            for (int i = Math.Max(0, y - 1); i >= 0; i--)
            {
                if (SeatMap[x, i] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[x, i] == 'L') // Seat is free
                {
                    break;
                }
            }

            // Check above them
            for (int i = Math.Max(0, x - 1); i >= 0; i--)
            {
                if (SeatMap[i, y] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[i, y] == 'L') // Seat is free
                {
                    break;
                }
            }

            // Check behind them
            for (int i = x + 1; i < SeatMap.GetLength(0); i++)
            {
                if (i < SeatMap.GetLength(0))
                {
                    if (SeatMap[i, y] == '#') // Seat is occupied, don't sit there
                    {
                        return true;
                    }
                    else if (SeatMap[i, y] == 'L') // Seat is free
                    {
                        break;
                    }
                }
            }


            // Check left top diagonal
            int copyX = x - 1;
            int copyY = y - 1;
            while (copyX >= 0 && copyY >= 0)
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }
                copyX--;
                copyY--;
            }

            // Check right top diagonal
            copyX = x - 1;
            copyY = y + 1;
            while (copyX >= 0 && copyY < SeatMap.GetLength(1))
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX--;
                copyY++;
            }

            // Check left bottom diagonal
            copyX = x + 1;
            copyY = y - 1;
            while (copyX < SeatMap.GetLength(0) && copyY >= 0)
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX++;
                copyY--;
            }

            // Check right bottom diagonal
            copyX = x + 1;
            copyY = y + 1;
            while (copyX < SeatMap.GetLength(0) && copyY < SeatMap.GetLength(1))
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    return true;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX++;
                copyY++;
            }


            return false;
        }

        private int CountOccupied(int x, int y)
        {
            int result = 0;
            // Check their right
            for (int i = y + 1; i < SeatMap.GetLength(1); i++)
            {
                if (i < SeatMap.GetLength(1))
                {
                    if (SeatMap[x, i] == '#') // Seat is occupied, don't sit there
                    {
                        result++;
                        break;
                    }
                    else if (SeatMap[x, i] == 'L') // Seat is free
                    {
                        break;
                    }
                }
            }

            // Check their left
            for (int i = Math.Max(0, y - 1); i >= 0; i--)
            {
                if (SeatMap[x, i] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[x, i] == 'L') // Seat is free
                {
                    break;
                }
            }

            // Check above them
            for (int i = Math.Max(0, x - 1); i >= 0; i--)
            {
                if (SeatMap[i, y] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[i, y] == 'L') // Seat is free
                {
                    break;
                }
            }

            // Check behind them
            for (int i = x + 1; i < SeatMap.GetLength(0); i++)
            {
                if (i < SeatMap.GetLength(0))
                {
                    if (SeatMap[i, y] == '#') // Seat is occupied, don't sit there
                    {
                        result++;
                        break;
                    }
                    else if (SeatMap[i, y] == 'L') // Seat is free
                    {
                        break;
                    }
                }
            }


            // Check left top diagonal
            int copyX = x - 1;
            int copyY = y - 1;
            while (copyX >= 0 && copyY >= 0)
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }
                copyX--;
                copyY--;
            }

            // Check right top diagonal
            copyX = x - 1;
            copyY = y + 1;
            while (copyX >= 0 && copyY < SeatMap.GetLength(1))
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX--;
                copyY++;
            }

            // Check left bottom diagonal
            copyX = x + 1;
            copyY = y - 1;
            while (copyX < SeatMap.GetLength(0) && copyY >= 0)
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX++;
                copyY--;
            }

            // Check right bottom diagonal
            copyX = x + 1;
            copyY = y + 1;
            while (copyX < SeatMap.GetLength(0) && copyY < SeatMap.GetLength(1))
            {
                if (SeatMap[copyX, copyY] == '#') // Seat is occupied, don't sit there
                {
                    result++;
                    break;
                }
                else if (SeatMap[copyX, copyY] == 'L') // Seat is free
                {
                    break;
                }

                copyX++;
                copyY++;
            }


            return result;
        }

        private char[,] CopyArray()
        {
            char[,] output = new char[SeatMap.GetLength(0), SeatMap.GetLength(1)];

            for (int i = 0; i < SeatMap.GetLength(0); i++)
            {
                for (int x = 0; x < SeatMap.GetLength(1); x++)
                {
                    output[i, x] = SeatMap[i, x];
                }
            }

            return output;
        }

        public void PrintSeatPlan()
        {
            for (int i = 0; i < SeatMap.GetLength(0); i++)
            {
                for (int j = 0; j < SeatMap.GetLength(1); j++)
                {
                    Console.Write(SeatMap[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("##############################");
        }

        private int CountOccupied()
        {
            int count = 0;
            for (int i = 0; i < SeatMap.GetLength(0); i++)
            {
                for (int j = 0; j < SeatMap.GetLength(1); j++)
                {
                    if (SeatMap[i, j] == '#')
                        count++;
                }

            }
            return count;
        }
    }
}
;