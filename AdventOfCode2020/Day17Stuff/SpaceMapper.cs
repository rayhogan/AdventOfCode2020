using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode2020.Day17Stuff
{
    public class SpaceMapper
    {

        struct Space3d
        {
            public int x;
            public int y;
            public int z;
        }

        struct Space4d
        {
            public int x;
            public int y;
            public int z;
            public int w;
        }

        List<Space3d> SpacePart1 = new List<Space3d>();
        List<Space4d> SpacePart2 = new List<Space4d>();
        public SpaceMapper(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    if (input[i][j] == '#')
                    {
                        SpacePart1.Add(new Space3d() { x = i, y = j, z = 0 });
                        SpacePart2.Add(new Space4d() { x = i, y = j, z = 0, w = 0 });
                    }
                }
            }

        }

        public int CountActivePart1()
        {
            int iterations = 0;
            int[] steps = { -1, 0, 1 };
            while (iterations < 6)
            {
                List<Space3d> buffer = new List<Space3d>();

                for (int x = -15; x <= 15; x++)
                {
                    for (int y = -15; y <= 15; y++)
                    {
                        for (int z = -15; z <= 15; z++)
                        {
                            Space3d checkPosition = new Space3d() { x = x, y = y, z = z };
                            int neighbour = 0;
                            foreach (int dx in steps)
                            {
                                foreach (int dy in steps)
                                {
                                    foreach (int dz in steps)
                                    {
                                        if (dx != 0 || dy != 0 || dz != 0)
                                        {
                                            Space3d checkNeighbour = new Space3d() { x = x + dx, y = y + dy, z = z + dz };
                                            if (SpacePart1.Contains(checkNeighbour))
                                                neighbour++;
                                        }
                                    }
                                }
                            }

                            if (!SpacePart1.Contains(checkPosition) && neighbour == 3)
                                buffer.Add(checkPosition);
                            else if (SpacePart1.Contains(checkPosition) && neighbour > 1 && neighbour < 4)
                                buffer.Add(checkPosition);
                        }
                    }
                }

                SpacePart1 = buffer;
                iterations++;
            }

            return SpacePart1.Count;
        }

        public int CountActivePart2()
        {
            int iterations = 0;
            int[] steps = { -1, 0, 1 };
            while (iterations < 6)
            {
                List<Space4d> buffer = new List<Space4d>();

                for (int x = SpacePart2.Select(i=>i.x).Min()-1; x <= SpacePart2.Select(i => i.x).Max()+2; x++)
                {
                    for (int y = SpacePart2.Select(i => i.y).Min() - 1; y <= SpacePart2.Select(i => i.y).Max() + 2; y++)
                    {
                        for (int z = SpacePart2.Select(i => i.z).Min()-1; z <= SpacePart2.Select(i => i.z).Max() + 2; z++)
                        {
                            for (int w = SpacePart2.Select(i => i.w).Min() - 1; w <= SpacePart2.Select(i => i.w).Max() + 2; w++)
                            {
                                Space4d checkPosition = new Space4d() { x = x, y = y, z = z, w = w };
                                int neighbour = 0;
                                foreach (int dx in steps)
                                {
                                    foreach (int dy in steps)
                                    {
                                        foreach (int dz in steps)
                                        {
                                            foreach (int dw in steps)
                                            {
                                                if (dx != 0 || dy != 0 || dz != 0 || dw != 0)
                                                {
                                                    Space4d checkNeighbour = new Space4d() { x = x + dx, y = y + dy, z = z + dz, w = w + dw };
                                                    if (SpacePart2.Contains(checkNeighbour))
                                                        neighbour++;
                                                }
                                            }
                                        }
                                    }
                                }

                                if (!SpacePart2.Contains(checkPosition) && neighbour == 3)
                                    buffer.Add(checkPosition);
                                else if (SpacePart2.Contains(checkPosition) && neighbour > 1 && neighbour < 4)
                                    buffer.Add(checkPosition);
                            }


                        }
                    }
                }
                SpacePart2 = buffer;
                iterations++;
            }

            return SpacePart2.Count;
        }
    }

}
