using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2019
{
    class Day10
    {
        public static int gcd(int a, int b)
        {
            if (b == 0)
                return a;
            return gcd(b, a % b);
        }

        public static void part1()
        {
            string[] lines = new StreamReader("day10.txt").ReadToEnd().Trim().Split();

            int max = 0;
            int sx = 0;
            int sy = 0;

            for(int y0 = 0; y0 < lines.Length; y0++)
            {
                for(int x0 = 0; x0 < lines[y0].Length; x0++)
                {
                    if(lines[y0][x0] == '#')
                    {
                        int count = 0;

                        for(int y = 0; y < lines.Length; y++)
                        {
                            for(int x = 0; x < lines[y].Length; x++)
                            {
                                if(lines[y][x] == '#' && !(y == y0 && x == x0))
                                {
                                    int dx = x - x0;
                                    int dy = y - y0;

                                    int denom = Math.Abs(gcd(dx, dy));
                                    for(int i = 1; i < denom; i++)
                                    {
                                        int ddx = dx / denom * i + x0;
                                        int ddy = dy / denom * i + y0;
                                        if (lines[ddy][ddx] == '#')
                                            goto skip;
                                    }
                                    count++;
                                }
skip:                           int a = 0;
                            }
                        }
                        if(count > max)
                        {
                            max = count;
                            sx = x0;
                            sy = y0;
                        }
                    }
                }
            }

            Console.WriteLine(max);
            Console.Read();
        }
    }
}
