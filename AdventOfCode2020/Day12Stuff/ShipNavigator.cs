using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Day12Stuff
{
    public class ShipNavigator
    {
        private List<(char, int)> Directions = new List<(char, int)>();
        public ShipNavigator(string[] input)
        {
            foreach (string s in input)
            {
                Directions.Add((s[0], Int32.Parse(s.Substring(1, s.Length - 1))));
            }
        }


        public int Part1Distance()
        {

            int xPlane = 0;
            int yPlane = 0;
            Direction direction = Direction.East;

            /*    x
             *    
             *    |
             * -------------  y
             *    |
             *    |
             *    |
             *    |
             */

            foreach ((char, int) instruction in Directions)
            {
                if (instruction.Item1 == 'N')
                {
                    xPlane += instruction.Item2;
                }
                else if (instruction.Item1 == 'S')
                {
                    xPlane -= instruction.Item2;
                }
                else if (instruction.Item1 == 'E')
                {
                    yPlane += instruction.Item2;
                }
                else if (instruction.Item1 == 'W')
                {
                    yPlane -= instruction.Item2;
                }
                else if (instruction.Item1 == 'L')
                {

                    int move = instruction.Item2 / 90;

                    for (int i = 0; i < move; i++)
                    {
                        if (direction == Direction.North)
                            direction = Direction.West;
                        else
                        {
                            direction--;
                        }
                    }
                }
                else if (instruction.Item1 == 'R')
                {
                    int move = instruction.Item2 / 90;

                    for (int i = 0; i < move; i++)
                    {
                        if (direction == Direction.West)
                            direction = Direction.North;
                        else
                        {
                            direction++;
                        }
                    }
                }
                else if (instruction.Item1 == 'F')
                {
                    if (direction == Direction.North)
                    {
                        xPlane += instruction.Item2;
                    }
                    else if (direction == Direction.South)
                    {
                        xPlane -= instruction.Item2;
                    }
                    else if (direction == Direction.East)
                    {
                        yPlane += instruction.Item2;
                    }
                    else if (direction == Direction.West)
                    {
                        yPlane -= instruction.Item2;
                    }
                    else
                    {
                        throw new Exception("Something terrible has happened. Take the kids and run!");
                    }
                }
                else
                {
                    throw new Exception("Unknown Instruction");
                }
            }
            Console.WriteLine("X: " + xPlane + " Y: " + yPlane);

            return Math.Abs(xPlane) + Math.Abs(yPlane);
        }

        public int Part2Distance()
        {

            int xPlane = 0;
            int yPlane = 0;
            int waypointX = 1;
            int waypointY = 10;

            /*    x
             *    
             *    |
             * -------------  y
             *    |
             *    |
             *    |
             *    |
             */

            foreach ((char, int) instruction in Directions)
            {
                if (instruction.Item1 == 'N')
                {
                    waypointX += instruction.Item2;
                }
                else if (instruction.Item1 == 'S')
                {
                    waypointX -= instruction.Item2;
                }
                else if (instruction.Item1 == 'E')
                {
                    waypointY += instruction.Item2;
                }
                else if (instruction.Item1 == 'W')
                {
                    waypointY -= instruction.Item2;
                }
                else if (instruction.Item1 == 'L')
                {
                    double radians = (Math.PI / 180) * instruction.Item2;
                    
                    int newWaypointY = waypointY * (int)Math.Cos(radians) - waypointX * (int)Math.Sin(radians);
                    int newWaypointX = waypointX * (int)Math.Cos(radians) + waypointY * (int)Math.Sin(radians);

                    waypointX = newWaypointX;
                    waypointY = newWaypointY;


                }
                else if (instruction.Item1 == 'R')
                {
                    double radians = (Math.PI / 180) * (-instruction.Item2);
                    int newWaypointY = waypointY * (int)Math.Cos(radians) - waypointX * (int)Math.Sin(radians);
                    int newWaypointX = waypointX * (int)Math.Cos(radians) + waypointY * (int)Math.Sin(radians);

                    waypointX = newWaypointX;
                    waypointY = newWaypointY;
                }
                else if (instruction.Item1 == 'F')
                {
                    xPlane += instruction.Item2 * waypointX;
                    yPlane += instruction.Item2 * waypointY;
                }
                else
                {
                    throw new Exception("Unknown Instruction");
                }
            }
            Console.WriteLine("X: " + xPlane + " Y: " + yPlane);

            return Math.Abs(xPlane) + Math.Abs(yPlane);
        }

        private enum Direction
        {
            North,
            East,
            South,
            West
        };
    }
}
