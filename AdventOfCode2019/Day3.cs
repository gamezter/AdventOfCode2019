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

            string[] firstLine = lines[0].Split(',');
            int x = 0, y = 0;

            foreach(string step in lines[0].Split(','))
            {
                char dir = step[0];
                int dist = int.Parse(step.Substring(1));
                switch (dir)
                {
                    case 'R':
                        for(int i = 0; i < dist; i++)
                        {
                            x++;
                            positions.Add((x, y));
                        }
                        break;
                    case 'U':
                        for (int i = 0; i < dist; i++)
                        {
                            y--;
                            positions.Add((x, y));
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < dist; i++)
                        {
                            x--;
                            positions.Add((x, y));
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < dist; i++)
                        {
                            y++;
                            positions.Add((x, y));
                        }
                        break;
                }
            }

            int min = int.MaxValue;

            x = 0;
            y = 0;

            foreach (string step in lines[1].Split(','))
            {
                char dir = step[0];
                int dist = int.Parse(step.Substring(1));
                switch (dir)
                {
                    case 'R':
                        for (int i = 0; i < dist; i++)
                        {
                            x++;
                            if(positions.Contains((x, y)))
                            {
                                if (min > Math.Abs(x) + Math.Abs(y))
                                    min = Math.Abs(x) + Math.Abs(y);
                            }
                        }
                        break;
                    case 'U':
                        for (int i = 0; i < dist; i++)
                        {
                            y--;
                            if (positions.Contains((x, y)))
                            {
                                if (min > Math.Abs(x) + Math.Abs(y))
                                    min = Math.Abs(x) + Math.Abs(y);
                            }
                        }
                        break;
                    case 'L':
                        for (int i = 0; i < dist; i++)
                        {
                            x--;
                            if (positions.Contains((x, y)))
                            {
                                if (min > Math.Abs(x) + Math.Abs(y))
                                    min = Math.Abs(x) + Math.Abs(y);
                            }
                        }
                        break;
                    case 'D':
                        for (int i = 0; i < dist; i++)
                        {
                            y++;
                            if (positions.Contains((x, y)))
                            {
                                if (min > Math.Abs(x) + Math.Abs(y))
                                    min = Math.Abs(x) + Math.Abs(y);
                            }
                        }
                        break;
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
