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
                int dx = 0, dy = 0;

                if (step[0] == 'R')
                    dx = 1;
                else if (step[0] == 'U')
                    dy = -1;
                else if (step[0] == 'L')
                    dx = -1;
                else if (step[0] == 'D')
                    dy = 1;

                int dist = int.Parse(step.Substring(1));

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
                int dx = 0, dy = 0;

                if (step[0] == 'R')
                    dx = 1;
                else if (step[0] == 'U')
                    dy = -1;
                else if (step[0] == 'L')
                    dx = -1;
                else if (step[0] == 'D')
                    dy = 1;

                int dist = int.Parse(step.Substring(1));

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
            string[] lines = new StreamReader("day3.txt").ReadToEnd().Trim().Split();
            Dictionary<(int, int), int> positions = new Dictionary<(int, int), int>();

            int x = 0, y = 0;
            int count = 0;

            foreach (string step in lines[0].Split(','))
            {
                int dx = 0, dy = 0;

                if (step[0] == 'R')
                    dx = 1;
                else if (step[0] == 'U')
                    dy = -1;
                else if (step[0] == 'L')
                    dx = -1;
                else if (step[0] == 'D')
                    dy = 1;

                int dist = int.Parse(step.Substring(1));

                for (int i = 0; i < dist; i++)
                {
                    x += dx;
                    y += dy;
                    count++;
                    positions[(x, y)] = count;
                }
            }

            int min = int.MaxValue;

            x = 0;
            y = 0;
            count = 0;

            foreach (string step in lines[1].Split(','))
            {
                int dx = 0, dy = 0;

                if (step[0] == 'R')
                    dx = 1;
                else if (step[0] == 'U')
                    dy = -1;
                else if (step[0] == 'L')
                    dx = -1;
                else if (step[0] == 'D')
                    dy = 1;

                int dist = int.Parse(step.Substring(1));

                for (int i = 0; i < dist; i++)
                {
                    x += dx;
                    y += dy;
                    count++;

                    if (positions.TryGetValue((x, y), out int val))
                    {
                        int time = val + count;
                        if (min > time)
                            min = time;
                    }
                }
            }

            Console.WriteLine(min);
            Console.Read();
        }
    }
}
