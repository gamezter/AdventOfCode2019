using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    class Day12
    {
        public static void part1()
        {
            int[] pos = new int[] { -14, -4, -11, -9, 6, -7, 4, 1, 4, 2, -14, -9 };
            int[] vel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 1000; i++)
            {
                for (int axis = 0; axis < 3; axis++)
                {
                    for (int l = axis; l < 12; l += 3)
                    {
                        for (int r = axis; r < 12; r += 3)
                        {
                            if (pos[l] < pos[r])
                            {
                                vel[l]++;
                                vel[r]--;
                            }
                        }
                    }

                    pos[axis + 0] += vel[axis + 0];
                    pos[axis + 3] += vel[axis + 3];
                    pos[axis + 6] += vel[axis + 6];
                    pos[axis + 9] += vel[axis + 9];
                }
            }

            for (int i = 0; i < 12; i++)
            {
                pos[i] = Math.Abs(pos[i]);
                vel[i] = Math.Abs(vel[i]);
            }

            int sum = 0;
            for(int i = 0; i < 12; i += 3)
            {
                int a = pos[i] + pos[i + 1] + pos[i + 2];
                int b = vel[i] + vel[i + 1] + vel[i + 2];
                sum += a * b;
            }

            Console.WriteLine(sum);
            Console.Read();
        }

        public static void part2()
        {
            int[] orig = new int[] { -14, -9, 4, 2, -4, 6, 1, -14, -11, -7, 4, -9 };
            int[] pos = new int[] { -14, -9, 4, 2, -4, 6, 1, -14, -11, -7, 4, -9 };
            int[] vel = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            long[] multiples = new long[] { 0, 0, 0 };

            for (int axis = 0; axis < 3; axis++)
            {
                int i0 = axis * 4 + 0;
                int i1 = axis * 4 + 1;
                int i2 = axis * 4 + 2;
                int i3 = axis * 4 + 3;

                int timeStep = 0;
                do
                {
                    for (int l = i0; l <= i3; l++)
                    {
                        for (int r = i0; r <= i3; r++)
                        {
                            if (pos[l] < pos[r])
                            {
                                vel[l]++;
                                vel[r]--;
                            }
                        }
                    }

                    pos[i0] += vel[i0];
                    pos[i1] += vel[i1];
                    pos[i2] += vel[i2];
                    pos[i3] += vel[i3];

                    timeStep++;
                }
                while (vel[i0] != 0 || vel[i1] != 0 || vel[i2] != 0 || vel[i3] != 0 || pos[i0] != orig[i0] || pos[i1] != orig[i1] || pos[i2] != orig[i2] || pos[i3] != orig[i3]);
                multiples[axis] = timeStep;
            }

            Console.WriteLine(lcm(lcm(multiples[0], multiples[1]), multiples[2]));
            Console.Read();
        }

        public static long lcm(long a, long b)
        {
            return a * b / gcd(a, b);
        }

        public static long gcd(long a, long b)
        {
            if (b == 0)
                return a;
            return gcd(b, a % b);
        }
    }
}
