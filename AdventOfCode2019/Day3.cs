using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day3
    {
        public static void part1()
        {
            string[] lines = new StreamReader("day3.txt").ReadToEnd().Trim().Split();
            HashSet<(int, int)> positions = new HashSet<(int, int)>();

            int x = 0, y = 0;

            foreach(string step in lines[0].Split(','))
            {
                char dir = step[0];
                int dist = int.Parse(step.Substring(1));

                int dx = 0, dy = 0;
                if (dir == 'R')
                    dx = 1;
                else if (dir == 'U')
                    dy = -1;
                else if (dir == 'L')
                    dx = -1;
                else if (dir == 'D')
                    dy = 1;

                for (int i = 0; i < dist; i++)
                {
                    x += dx;
                    y += dy;
                    positions.Add((x, y));
                }
            }

            int min = int.MaxValue;

            x = 0;
            y = 0;

            foreach (string step in lines[1].Split(','))
            {
                char dir = step[0];
                int dist = int.Parse(step.Substring(1));

                int dx = 0, dy = 0;

                if (dir == 'R')
                    dx = 1;
                else if (dir == 'U')
                    dy = -1;
                else if (dir == 'L')
                    dx = -1;
                else if (dir == 'D')
                    dy = 1;

                for (int i = 0; i < dist; i++)
                {
                    x += dx;
                    y += dy;

                    if (positions.Contains((x, y)))
                    {
                        int manDist = Math.Abs(x) + Math.Abs(y);
                        if (min > manDist)
                            min = manDist;
                    }
                }
            }

            Console.WriteLine(min);
            Console.Read();
        }

        public static void part2()
        {

        }
    }
}
