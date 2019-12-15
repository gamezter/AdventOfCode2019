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

            for(int y0 = 0; y0 < lines.Length; y0++)
            {
                for(int x0 = 0; x0 < lines[y0].Length; x0++)
                {
                    if (lines[y0][x0] != '#')
                        continue;   

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
skip:                       int a = 0;
                        }
                    }

                    if(count > max)
                        max = count;
                }
            }

            Console.WriteLine(max);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = new StreamReader("day10.txt").ReadToEnd().Trim().Split();

            int max = 0;
            int sx = 0;
            int sy = 0;

            for (int y0 = 0; y0 < lines.Length; y0++)
            {
                for (int x0 = 0; x0 < lines[y0].Length; x0++)
                {
                    if (lines[y0][x0] != '#')
                        continue;

                    int count = 0;

                    for (int y = 0; y < lines.Length; y++)
                    {
                        for (int x = 0; x < lines[y].Length; x++)
                        {
                            if (lines[y][x] == '#' && !(y == y0 && x == x0))
                            {
                                int dx = x - x0;
                                int dy = y - y0;

                                int denom = Math.Abs(gcd(dx, dy));
                                for (int i = 1; i < denom; i++)
                                {
                                    int ddx = dx / denom * i + x0;
                                    int ddy = dy / denom * i + y0;
                                    if (lines[ddy][ddx] == '#')
                                        goto skip;
                                }
                                count++;
                            }
                            skip: int a = 0;
                        }
                    }

                    if (count > max)
                    {
                        max = count;
                        sx = x0;
                        sy = y0;
                    }
                }
            }

            List<(int dx, int dy, double mag)> deltas = new List<(int dx, int dy, double mag)>();

            for (int y0 = 0; y0 < lines.Length; y0++)
            {
                for (int x0 = 0; x0 < lines[y0].Length; x0++)
                {
                    if (lines[y0][x0] != '#' || (x0 == sx && y0 == sy))
                        continue;
                    int dx = x0 - sx;
                    int dy = y0 - sy;
                    double mag = Math.Sqrt(dx * dx + dy * dy);
                    deltas.Add((dx, dy, mag));
                }
            }

            //find first
            int min = -1;
            for (int i = 0; i < deltas.Count; i++)
            {
                var delta = deltas[i];
                if(delta.dx == 0 && delta.dy < 0)
                {
                    if (min == -1 || deltas[min].mag < delta.mag)
                        min = i;
                }
            }

            var from = deltas[min];

            deltas.RemoveAt(min);

            for (int j = 1; j < 200; j++)
            {
                double minAngle = double.MaxValue;
                double minDistance = int.MaxValue;
                int index = 0;
                for (int i = 0; i < deltas.Count; i++)
                {
                    double angle = signedAngle(from, deltas[i]);
                    
                    if (angle <= 0)
                        continue;

                    if (angle < minAngle || (angle == minAngle && deltas[i].mag < minDistance))
                    {
                        minAngle = angle;
                        minDistance = deltas[i].mag;
                        index = i;
                    }
                }

                from = deltas[index];

                deltas.RemoveAt(index);
            }

            Console.WriteLine((from.dx + sx) * 100 + from.dy + sy);
            Console.Read();
        }

        public static double signedAngle((int x, int y, double mag) from, (int x, int y, double mag) to)
        {
            double denominator = from.mag * to.mag;
            double dot = (from.x * to.x + from.y * to.y) / denominator;
            double angle = Math.Acos(dot);
            int sign = Math.Sign(from.x * to.y - to.x * from.y);
            return angle * sign;
        }
    }
}
